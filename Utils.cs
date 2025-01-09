        internal static void horizontalSplitter(float height)
        {
            ImGui.InvisibleButton("hsplitter", new Vector2(-1, 8.0f));
            if (ImGui.IsItemActive())
                height += ImGui.GetIO().MouseDelta.Y;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        // DllImport für GetAsyncKeyState
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int nVirtKey);

        // DllImport für MapVirtualKey
        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        // Eine vollständige Mapping-Tabelle für Tastenbezeichner
        private static readonly Dictionary<int, string> KeyNames = new Dictionary<int, string>
    {
        { 0x00, "Null" },
        { 0x01, "Left Mouse Button" },
        { 0x02, "Right Mouse Button" },
        { 0x03, "Control Break" },
        { 0x04, "Middle Mouse Button" },
        { 0x05, "Extra Mouse Button 1" },
        { 0x06, "Extra Mouse Button 2" },
        { 0x08, "Backspace" },
        { 0x09, "Tab" },
        { 0x0C, "Clear" },
        { 0x0D, "Enter" },
        { 0x10, "Shift" },
        { 0x11, "Ctrl" },
        { 0x12, "Alt" },
        { 0x13, "Pause" },
        { 0x14, "Caps Lock" },
        { 0x1B, "Escape" },
        { 0x20, "Space" },
        { 0x21, "Page Up" },
        { 0x22, "Page Down" },
        { 0x23, "End" },
        { 0x24, "Home" },
        { 0x25, "Left Arrow" },
        { 0x26, "Up Arrow" },
        { 0x27, "Right Arrow" },
        { 0x28, "Down Arrow" },
        { 0x29, "Select" },
        { 0x2A, "Print" },
        { 0x2B, "Execute" },
        { 0x2C, "Print Screen" },
        { 0x2D, "Insert" },
        { 0x2E, "Delete" },
        { 0x30, "0" },
        { 0x31, "1" },
        { 0x32, "2" },
        { 0x33, "3" },
        { 0x34, "4" },
        { 0x35, "5" },
        { 0x36, "6" },
        { 0x37, "7" },
        { 0x38, "8" },
        { 0x39, "9" },
        { 0x41, "A" },
        { 0x42, "B" },
        { 0x43, "C" },
        { 0x44, "D" },
        { 0x45, "E" },
        { 0x46, "F" },
        { 0x47, "G" },
        { 0x48, "H" },
        { 0x49, "I" },
        { 0x4A, "J" },
        { 0x4B, "K" },
        { 0x4C, "L" },
        { 0x4D, "M" },
        { 0x4E, "N" },
        { 0x4F, "O" },
        { 0x50, "P" },
        { 0x51, "Q" },
        { 0x52, "R" },
        { 0x53, "S" },
        { 0x54, "T" },
        { 0x55, "U" },
        { 0x56, "V" },
        { 0x57, "W" },
        { 0x58, "X" },
        { 0x59, "Y" },
        { 0x5A, "Z" },
        { 0x5B, "Left Windows" },
        { 0x5C, "Right Windows" },
        { 0x5D, "Application" },
        { 0x5E, "Reserved" },
        { 0x5F, "Sleep" },
        { 0x60, "Num 0" },
        { 0x61, "Num 1" },
        { 0x62, "Num 2" },
        { 0x63, "Num 3" },
        { 0x64, "Num 4" },
        { 0x65, "Num 5" },
        { 0x66, "Num 6" },
        { 0x67, "Num 7" },
        { 0x68, "Num 8" },
        { 0x69, "Num 9" },
        { 0x6A, "Num *" },
        { 0x6B, "Num +" },
        { 0x6C, "Num ," },
        { 0x6D, "Num -" },
        { 0x6E, "Num ." },
        { 0x6F, "Num /" },
        { 0x70, "F1" },
        { 0x71, "F2" },
        { 0x72, "F3" },
        { 0x73, "F4" },
        { 0x74, "F5" },
        { 0x75, "F6" },
        { 0x76, "F7" },
        { 0x77, "F8" },
        { 0x78, "F9" },
        { 0x79, "F10" },
        { 0x7A, "F11" },
        { 0x7B, "F12" },
        { 0x7C, "F13" },
        { 0x7D, "F14" },
        { 0x7E, "F15" },
        { 0x7F, "F16" },
        { 0x80, "F17" },
        { 0x81, "F18" },
        { 0x82, "F19" },
        { 0x83, "F20" },
        { 0x84, "F21" },
        { 0x85, "F22" },
        { 0x86, "F23" },
        { 0x87, "F24" },
        { 0x90, "Num Lock" },
        { 0x91, "Scroll Lock" },
        { 0xA0, "Left Shift" },
        { 0xA1, "Right Shift" },
        { 0xA2, "Left Control" },
        { 0xA3, "Right Control" },
        { 0xA4, "Left Menu" },
        { 0xA5, "Right Menu" },
        { 0xA6, "Browser Back" },
        { 0xA7, "Browser Forward" },
        { 0xA8, "Browser Refresh" },
        { 0xA9, "Browser Stop" },
        { 0xAA, "Browser Search" },
        { 0xAB, "Browser Favorites" },
        { 0xAC, "Browser Home" },
        { 0xAD, "Volume Mute" },
        { 0xAE, "Volume Down" },
        { 0xAF, "Volume Up" },
        { 0xB0, "Next Track" },
        { 0xB1, "Previous Track" },
        { 0xB2, "Stop Media" },
        { 0xB3, "Play/Pause Media" },
        { 0xB4, "Launch Mail" },
        { 0xB5, "Select Media" },
        { 0xB6, "Launch App 1" },
        { 0xB7, "Launch App 2" },
        { 0xC0, "Power" },
        { 0xC1, "Sleep" },
        { 0xC2, "Wake" }
    };

        /// <summary>
        /// Rendert einen Button, der den aktuellen Key anzeigt und es erlaubt, einen neuen Key zuzuweisen.
        /// </summary>
        /// <param name="buttonKeyName">Der Name des Buttons.</param>
        /// <param name="capturedKey">Der aktuelle Key, der geändert werden kann (als int).</param>
        /// <returns>True, wenn ein neuer Key zugewiesen wurde.</returns>
        public static bool RenderKeyButton(string buttonKeyName, ref int capturedKey)
        {
            bool keyCaptured = false;

            string keyName = capturedKey != 0 ? GetKeyName(capturedKey) : "Press a key...";

            if (ImGui.Button($"{buttonKeyName} : {keyName}", new System.Numerics.Vector2(200, 25)))
            {
                capturedKey = 0;
            }

            if (capturedKey == 0)
            {
                ImGui.Text("Press any key...");

                for (int key = 0; key < 256; ++key)
                {
                    if ((GetAsyncKeyState(key) & 0x8000) != 0)
                    {
                        capturedKey = key;
                        keyCaptured = true;
                        break;
                    }
                }
            }

            return keyCaptured;
        }

        /// <summary>
        /// Gibt den Namen der Taste basierend auf dem virtuellen Tastencode zurück.
        /// </summary>
        /// <param name="keyCode">Der virtuelle Tastencode.</param>
        /// <returns>Der Name der Taste.</returns>
        public static string GetKeyName(int keyCode)
        {
            return KeyNames.ContainsKey(keyCode) ? KeyNames[keyCode] : $"Key Code: {keyCode}";
        }

    public static void VerticalTabBar(string[] tabNames, ref int selectedTab)
    {
        ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 1.0f);
        ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 0.0f);

        for (var i = 0; i < tabNames.Length; ++i)
            if (ImGui.Button(tabNames[i], new Vector2(-1, 30)))
                selectedTab = i;

        ImGui.PopStyleVar(2);
    }

    private static readonly ImmutableArray<(string Title, Action RenderPage)> PagesArray = new[]
    {
        ("ESP", new Action(test)),
        ("Aim Bot", new Action(RenderAimBotPage))
    }.ToImmutableArray();

    public static void RenderMenu()
    {
        ImGui.Begin("Styled Menu");
        {
            ImGui.SetWindowSize(new Vector2(500, 300));
            ImGui.BeginChild("TabsAndContent", new Vector2(150, -1), true, ImGuiWindowFlags.None);
            {
                ImGuiHelper.VerticalTabBar(PagesArray.Select(x => x.Title).ToArray(), ref Main.SelectedTab);
            }
            ImGui.EndChild();
            ImGui.SameLine();
            ImGui.BeginChild("MainContent", new Vector2(0, -1), true, ImGuiWindowFlags.None);
            {
                PagesArray.Select(x => x.RenderPage).ElementAt(Main.SelectedTab).Invoke();
            }
            ImGui.EndChild();
        }
        ImGui.End();
    }

    public static void RenderAimBotPage()
    {
        ImGui.TextUnformatted("Aimbot Options:");
        ImGui.Separator();
        {
            ImGui.BeginGroup();

            ImGui.EndGroup();
        }
    }

        public bool CheckWindow(Process process)
        {
            if (this.GetActiveWindowTitle() == process.MainWindowTitle || this.GetActiveWindowTitle() == this.title)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void DrawOverlay()
        {
            ImGui.SetNextWindowPos(new Vector2(0, 0));
            ImGui.SetNextWindowSize(new Vector2 (ScreenX, ScreenY));
            if (ImGui.Begin("Overlay", ImGuiWindowFlags.NoDecoration
                | ImGuiWindowFlags.NoBackground
                | ImGuiWindowFlags.NoBringToFrontOnFocus
                | ImGuiWindowFlags.NoMove
                | ImGuiWindowFlags.NoInputs
                | ImGuiWindowFlags.NoCollapse
                | ImGuiWindowFlags.NoScrollbar
                | ImGuiWindowFlags.NoScrollWithMouse
                | ImGuiWindowFlags.NoSavedSettings
                )
            )
            {
                ImGui.PushFont(ImGuiRenderer.WatermarkScale);

                // Draw Text, Box, Others

                ImGui.PopFont();
                ImGui.End();
            }

        internal static void verticalSplitter(float width, float height)
        {
            ImGui.SameLine();
            ImGui.InvisibleButton("vsplitter", new Vector2(8.0f, height));
            if (ImGui.IsItemActive())
                width += ImGui.GetIO().MouseDelta.X;
            ImGui.SameLine();
        }

        public static void CentreText(string text)
        {
            float windowWidth = ImGui.GetWindowSize().X, textWidth = ImGui.CalcTextSize(text).X;
            ImGui.SetCursorPosX((windowWidth - textWidth) * .5f);
            ImGui.Text(text);
        }

        public static void CentreText(string text, Color color)
        {
            float windowWidth = ImGui.GetWindowSize().X, textWidth = ImGui.CalcTextSize(text).X;
            ImGui.SetCursorPosX((windowWidth - textWidth) * .5f);
            ImGui.TextColored(new Vector4(color.R, color.G, color.B, color.A), text);
        }

        public static void ApplyTooltip(string text)
        {
            if (!ImGui.IsItemHovered()) return;
            ImGui.BeginTooltip();
            ImGui.SetTooltip(text);
            ImGui.EndTooltip();
        }

        public static Vector4 getColor(Color color) => new Vector4(color.R, color.G, color.B, color.A);

        public static void NewLine(int value)
        {
            for (int i = 0; i < value; i++)
            {
                ImGui.NewLine();
            }
        }

        public static void statusText(int status, string text = "")
        {
            switch(status)
            {
                case 1:
                    ImGui.SameLine();
                    ImGui.TextColored(getColor(Color.Green), "[Undetected]");
                    break;
                case 2:
                    ImGui.SameLine();
                    ImGui.TextColored(getColor(Color.Orange), "[Own Risk]");
                    break;
                case 3:
                    ImGui.SameLine();
                    ImGui.TextColored(getColor(Color.Red), "[Detected]");
                    break;
                case 4:
                    ImGui.SameLine();
                    ImGui.TextColored(getColor(Color.Yellow), $"[{text}]");
                    break;
            }
        }
        
        internal static void tabButton(string[] textButton, Vector2 sizeButton)
        {
            ImGui.BeginGroup();
            for (int i = 0; i < textButton.Length; i++)
            {
                if (ImGui.Button(textButton[i], sizeButton))
                {
                    Cfg_Settings.MenutabCount = i;
                }
                ImGui.SameLine();
            }
            ImGui.EndGroup();
        }
