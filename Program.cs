/*
 * File: Program.cs
 * Project: cs2-autoaccept
 * Created Date: 03.06.2021 10:27:00
 * Author: 3urobeat
 *
 * Last Modified: 11.11.2023 17:51:32
 * Modified By: 3urobeat
 *
 * Copyright (c) 2021 3urobeat <https://github.com/3urobeat>
 *
 * This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.
 */


using System;
using System.Timers;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace cs2autoaccept
{
    class MainClass
    {
        private static System.Timers.Timer aTimer;
        private static int i; // Track iteration

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo); // https://stackoverflow.com/a/7121314


        // Entry point
        public static void Main()
        {
            String version       = "1.2";
            int    checkInterval = 4000;  // Time in ms between searches

            Console.Title = "cs2-autoaccept v" + version + " by 3urobeat";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n            cs2-autoaccept version {0} by 3urobeat", version);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Checking your screen for a 'Accept' window every {0} second(s)...\n", checkInterval / 1000);


            // Interval using a timer: https://docs.microsoft.com/de-de/dotnet/api/system.timers.timer.interval?view=net-5.0
            aTimer = new System.Timers.Timer();
            aTimer.Interval = checkInterval;

            aTimer.Elapsed += OnTimedEvent; // Hook up the Elapsed event for the timer
            aTimer.Enabled = true;          // Start the timer (will automatically reset because AutoReset is true by default)

            while (true) {} // Prevents window from instantly closing
        }


        // Catch Interval Event to search screen for accept window
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            i++; // Count this iteration

            Console.Write($"\r[{i}] Searching..."); // Replace previous line so that only i seems to change

            // Take screenshot from user's primary screen and save it to a bitmap to be able to search it for the green accept window (https://stackoverflow.com/a/363008)
            Bitmap   bm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); // Create a new bitmap
            Graphics gp = Graphics.FromImage(bm);

            gp.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);


            // Search the bitmap for large amount of green pixels
            // This should be better than for example searching for the accept button with a dummy image because different languages or resolutions could probably affect the result

            // Define the two colors the Accept button is made out of (see accept_button.jpg in repo for reference)
            Color color1 = Color.FromArgb(54, 183, 82); // https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color.fromargb?view=net-5.0#System_Drawing_Color_FromArgb_System_Int32_System_Int32_System_Int32_
            Color color2 = Color.FromArgb(20, 61, 11);

            int  matches   = 0;     // Count the amount of matching pixels
            bool breakLoop = false; // Can be set to true to prematurely abort loop if we found enough matching pixels

            for (int x = 0; x < bm.Width && !breakLoop; x++) // Iterate over all pixels in x range
            {
                for (int y = 0; y < bm.Height && !breakLoop; y++) // Iterate over all pixels in y range inside the other loop to effectively get all pixelsQ
                {
                    Color currentPixelColor = bm.GetPixel(x, y); // Get current pixel to check color of it (GetPixel method returns the color of the pixel: https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap.getpixel?view=net-5.0)

                    if (currentPixelColor == color1 || currentPixelColor == color2) // Check if the color of this pixel matches one of the two colors we are searching for
                    {
                        matches++;

                        if (matches > 10000) // If we got 10000 matching pixels then it surely is the Accept button
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\r[{i}] Found button! Accepting match...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\nIf everyone accepted and you are in the loading screen then please close this window.\nI will otherwise continue searching.\n");

                            // Setting cursor position to the current pixel (which must be part of the button) and clicking
                            SetCursorPos(x, y);

                            mouse_event(0x00000002, x, y, 0, 0); // LeftDown (mouse event flags: https://stackoverflow.com/a/7121314)
                            mouse_event(0x00000004, x, y, 0, 0); // LeftUp

                            // Stop loop prematurely
                            breakLoop = true;
                            break;
                        }
                    }
                }
            }

            // Console.WriteLine("Matches: " + matches.ToString()); // Enable to debug amount of matches found


            // Clean up when we are done checking this screenshot
            bm = null;
            gp = null;
            GC.Collect();
        }
    }
}
