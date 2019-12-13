using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class RecipeEditor : ComponentBase
    {
        [Parameter]
        public recipe Model { get; set; }
        public List<style> styleOptions = getStyleOptions();

        public static List<style> getStyleOptions()
        {
            style a = new style();
            a.name = "test";
            a.description = "no";

            style b = new style();
            a.name = "test2";
            a.description = "no2";

            List<style> styles = new List<style>();

            styles.Add(a);
            styles.Add(b);

            return styles;
        }

    }

    
}
