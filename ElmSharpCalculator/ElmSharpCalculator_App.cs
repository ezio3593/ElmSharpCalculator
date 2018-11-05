using Tizen.Applications;
using ElmSharp;

using Calculator.Views;
using Calculator.Impl;
using System;

namespace ElmSharpCalculator
{
    class ElmSharpCalculator_App : CoreUIApplication
    {
        public static string[,] imageNames = new string[5, 4]
        {
            {
                "calculator_button_p_01.png",
                "calculator_button_p_02.png",
                "calculator_button_p_03.png",
                "calculator_button_p_04.png"
            },
            {
                "calculator_button_p_number_7.png",
                "calculator_button_p_number_8.png",
                "calculator_button_p_number_9.png",
                "calculator_button_p_05.png"
            },
            {
                "calculator_button_p_number_4.png",
                "calculator_button_p_number_5.png",
                "calculator_button_p_number_6.png",
                "calculator_button_p_06.png"
            },
            {
                "calculator_button_p_number_1.png",
                "calculator_button_p_number_2.png",
                "calculator_button_p_number_3.png",
                "calculator_button_p_07.png"
            },
            {
                "calculator_button_p_number_0.png",
                "calculator_button_p_number_10.png",
                "calculator_button_p_number_11.png",
                "calculator_button_p_08.png"
            }
        };

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window window = new Window("ElmSharpApp")
            {
                AvailableRotations = DisplayRotation.Degree_0 | DisplayRotation.Degree_180 | DisplayRotation.Degree_270 | DisplayRotation.Degree_90
            };
            window.BackButtonPressed += (s, e) =>
            {
                Exit();
            };
            window.Show();

            var box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();

            var bg = new Background(window)
            {
                Color = Color.White
            };
            bg.SetContent(box);

            var conformant = new Conformant(window);
            conformant.Show();
            conformant.SetContent(bg);

            for (int i = 0; i < 5; i++)
            {
                var buttonRow = new Box(box);
                buttonRow.IsHorizontal = true;
                buttonRow.Show();

                for (int j = 0; j < 4; j++)
                {
                    var button = new Image(buttonRow);
                    button.File = String.Concat(DirectoryInfo.Resource, "/", imageNames[i, j]);
                    button.Show();

                    buttonRow.Pack(button);
                }

                box.Pack(buttonRow);
            }
        }

        static void Main(string[] args)
        {
            Elementary.Initialize();
            Elementary.ThemeOverlay();
            ElmSharpCalculator_App app = new ElmSharpCalculator_App();
            app.Run(args);
        }
    }
}
