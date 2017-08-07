﻿using System.Collections.Generic;
using System.Web.UI;

namespace ConsumersTest.Infrastructure.Extension
{
    public static class PageExtensions
    {
        public static IEnumerable<Control> All(this ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                foreach (Control grandChild in control.Controls.All())
                    yield return grandChild;

                yield return control;
            }
        }
    }
}