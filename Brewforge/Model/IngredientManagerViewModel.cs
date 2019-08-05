using Beernet_Lib.Models;
using System;
using System.Collections.Generic;

namespace Brewforge.Models
{
    /// <summary>
    /// View Model to post to the editor page.
    /// </summary>
    public class IngredientManagerViewModel
    {
        /// <summary>
        /// A list of all the yeasts from the server.  Used to populated the yeast dropdown.
        /// </summary>
        public List<hopbase> hopOptions { get; set; }

        /// <summary>
        /// A list of all the adjuncts from the server.  Used to populated the adjunct dropdown.
        /// </summary>
        public List<fermentable> fermentableOptions { get; set; }

        /// <summary>
        /// A list of all the yeasts from the server.  Used to populated the yeast dropdown.
        /// </summary>
        public List<yeast> yeastOptions { get; set; }

        /// <summary>
        /// A list of all the adjuncts from the server.  Used to populated the adjunct dropdown.
        /// </summary>
        public List<adjunct> adjunctOptions { get; set; }

        /// <summary>
        /// A list of all the adjuncts from the server.  Used to populated the adjunct dropdown.
        /// </summary>
        public List<style> styleOptions { get; set; }

        /// <summary>
        /// This index of the selected fermentable in the fermentable dropdown.
        /// </summary>
        public int selectedFermentableIndex { get; set; }

        /// <summary>
        /// The index of the selected hop in the hop dropdown.
        /// </summary>
        public int selectedHopIndex { get; set; }

        /// <summary>
        /// The index of the selected yeast in the yeast dropdown.
        /// </summary>
        public int selectedYeastIndex { get; set; }

        /// <summary>
        /// The index of the selected adjunct in the yeast dropdown.
        /// </summary>
        public int selectedAdjunctIndex { get; set; }
        
        /// <summary>
        /// The selected style of the current beer.
        /// </summary>
        public int selectedStyleIndex { get; set; }
    }
}