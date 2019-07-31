using Beernet_Lib.Models;
using System;
using System.Collections.Generic;

namespace Brewforge.Models
{
    /// <summary>
    /// View Model to post to the editor page.
    /// </summary>
    public class EditorViewModel
    {
        /// <summary>
        /// The entire currently loaded recipe.
        /// </summary>
        public recipe currentRecipe { get; set; }

        /// <summary>
        /// The selected Hop Addition.  Used to populate the hop editor form section.
        /// </summary>
        public hopAddition selectedHopAddition { get; set; }

        /// <summary>
        /// The selected Fermentable Additon.  Used to populated the fermentable editor form secton.
        /// </summary>
        public fermentableAddition selectedFermentableAddition { get; set; }

        /// <summary>
        /// The selected Yeast Additon (It is just a yeast object though).  Used to populated the yeast editor form secton.
        /// </summary>
        public yeastAddition selectedYeastAddition { get; set; }

        /// <summary>
        /// The selected Yeast Additon (It is just a yeast object though).  Used to populated the yeast editor form secton.
        /// </summary>
        public adjunctAddition selectedAdjunctAddition { get; set; }

        /// <summary>
        /// A list of all the hops from the server.  Used to populate the hop dropdown.
        /// </summary>
        public List<hopbase> hopOptions { get; set; }

        /// <summary>
        /// A list of all the fermentables from the server.  Used to populated the fermentable dropdown.
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
        /// The index of the selected fermentable addition from the list of fermentable additions in the recipe.
        /// </summary>
        public int selectedFermentableAdditionIndex {get;set;}

        /// <summary>
        /// The index of the selected hop addition from the list of fermentable additions in the recipe.
        /// </summary>
        public int selectedHopAdditionIndex { get; set; }

        /// <summary>
        /// The index of the selected yeast addition from the list of yeast additions in the recipe.
        /// </summary>
        public int selectedYeastAdditionIndex { get; set; }

        /// <summary>
        /// The index of the selected adjunct addition from the list of yeast additions in the recipe.
        /// </summary>
        public int selectedAdjunctAdditionIndex { get; set; }

        /// <summary>
        /// The selected style of the current beer.
        /// </summary>
        public style style { get; set; }


        /// <summary>
        /// The different style options.
        /// </summary>
        public List<style> styleOptions { get; set; }

    }
}