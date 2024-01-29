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
