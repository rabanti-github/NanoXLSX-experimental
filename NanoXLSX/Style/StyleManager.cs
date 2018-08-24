﻿/*
 * NanoXLSX is a small .NET library to generate and read XLSX (Microsoft Excel 2007 or newer) files in an easy and native way
 * Copyright Raphael Stoeckli © 2018
 * This library is licensed under the MIT License.
 * You find a copy of the license in project folder or on: http://opensource.org/licenses/MIT
 */

using System;
using System.Collections.Generic;
using NanoXLSX.Exception;

namespace NanoXLSX.Style
{
    /// <summary>
    /// Class representing a style manager to maintain all styles and its components of a workbook
    /// </summary>
    public class StyleManager
    {
        #region constants
        /// <summary>
        /// Prefix for the hash calculation of border styles
        /// </summary>
        public const string BORDERPREFIX = "borders@";
        /// <summary>
        /// Prefix for the hash calculation of cellXf styles
        /// </summary>
        public const string CELLXFPREFIX = "/cellXf@";
        /// <summary>
        /// Prefix for the hash calculation of fill styles
        /// </summary>
        public const string FILLPREFIX = "/fill@";
        /// <summary>
        /// Prefix for the hash calculation of font styles
        /// </summary>
        public const string FONTPREFIX = "/font@";
        /// <summary>
        /// Prefix for the hash calculation of number format styles
        /// </summary>
        public const string NUMBERFORMATPREFIX = "/numberFormat@";
        /// <summary>
        /// Prefix for the hash calculation of styles
        /// </summary>
        public const string STYLEPREFIX = "style=";
        #endregion

        #region privateFields
        private List<AbstractStyle> borders;
        private List<AbstractStyle> cellXfs;
        private List<AbstractStyle> fills;
        private List<AbstractStyle> fonts;
        private List<AbstractStyle> numberFormats;
        private List<AbstractStyle> styles;
        private List<string> styleNames;
        #endregion

        #region constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public StyleManager()
        {
            borders = new List<AbstractStyle>();
            cellXfs = new List<AbstractStyle>();
            fills = new List<AbstractStyle>();
            fonts = new List<AbstractStyle>();
            numberFormats = new List<AbstractStyle>();
            styles = new List<AbstractStyle>();
            styleNames = new List<string>();
        }
        #endregion

        #region methods

        /// <summary>
        /// Gets a component by its hash
        /// </summary>
        /// <param name="list">List to check</param>
        /// <param name="hash">Hash of the component</param>
        /// <returns>Determined component. If not found, null will be returned</returns>
        private AbstractStyle GetComponentByHash(ref List<AbstractStyle> list, string hash)
        {
            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                if (list[i].Hash == hash)
                {
                    return list[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Gets a border by its hash
        /// </summary>
        /// <param name="hash">Hash of the border</param>
        /// <returns>Determined border</returns>
        /// <exception cref="StyleException">Throws a StyleException if the border was not found in the style manager</exception>
        public NanoXLSX.Style.Style.Border GetBorderByHash(String hash)
        {
            AbstractStyle component = GetComponentByHash(ref borders, hash);
            if (component == null)
            {
                throw new StyleException("MissingReferenceException", "The style component with the hash '" + hash + "' was not found");
            }
            return (NanoXLSX.Style.Style.Border)component;
        }

        /// <summary>
        /// Gets all borders of the style manager
        /// </summary>
        /// <returns>Array of borders</returns>
        public NanoXLSX.Style.Style.Border[] GetBorders()
        {
            return Array.ConvertAll(borders.ToArray(), x => (NanoXLSX.Style.Style.Border)x);
        }

        /// <summary>
        /// Gets the number of borders in the style manager
        /// </summary>
        /// <returns>Number of stored borders</returns>
        public int GetBorderStyleNumber()
        {
            return borders.Count;
        }

        /* ****************************** */

        /// <summary>
        /// Gets a cellXf by its hash
        /// </summary>
        /// <param name="hash">Hash of the cellXf</param>
        /// <returns>Determined cellXf</returns>
        /// <exception cref="StyleException">Throws a StyleException if the cellXf was not found in the style manager</exception>
        public NanoXLSX.Style.Style.CellXf GetCellXfByHash(String hash)
        {
            AbstractStyle component = GetComponentByHash(ref cellXfs, hash);
            if (component == null)
            {
                throw new StyleException("MissingReferenceException", "The style component with the hash '" + hash + "' was not found");
            }
            return (NanoXLSX.Style.Style.CellXf)component;
        }

        /// <summary>
        /// Gets all cellXfs of the style manager
        /// </summary>
        /// <returns>Array of cellXfs</returns>
        public NanoXLSX.Style.Style.CellXf[] GetCellXfs()
        {
            return Array.ConvertAll(cellXfs.ToArray(), x => (NanoXLSX.Style.Style.CellXf)x);
        }

        /// <summary>
        /// Gets the number of cellXfs in the style manager
        /// </summary>
        /// <returns>Number of stored cellXfs</returns>
        public int GetCellXfStyleNumber()
        {
            return cellXfs.Count;
        }

        /* ****************************** */

        /// <summary>
        /// Gets a fill by its hash
        /// </summary>
        /// <param name="hash">Hash of the fill</param>
        /// <returns>Determined fill</returns>
        /// <exception cref="StyleException">Throws a StyleException if the fill was not found in the style manager</exception>
        public NanoXLSX.Style.Style.Fill GetFillByHash(String hash)
        {
            AbstractStyle component = GetComponentByHash(ref fills, hash);
            if (component == null)
            {
                throw new StyleException("MissingReferenceException", "The style component with the hash '" + hash + "' was not found");
            }
            return (NanoXLSX.Style.Style.Fill)component;
        }

        /// <summary>
        /// Gets all fills of the style manager
        /// </summary>
        /// <returns>Array of fills</returns>
        public NanoXLSX.Style.Style.Fill[] GetFills()
        {
            return Array.ConvertAll(fills.ToArray(), x => (NanoXLSX.Style.Style.Fill)x);
        }

        /// <summary>
        /// Gets the number of fills in the style manager
        /// </summary>
        /// <returns>Number of stored fills</returns>
        public int GetFillStyleNumber()
        {
            return fills.Count;
        }

        /* ****************************** */

        /// <summary>
        /// Gets a font by its hash
        /// </summary>
        /// <param name="hash">Hash of the font</param>
        /// <returns>Determined font</returns>
        /// <exception cref="StyleException">Throws a StyleException if the font was not found in the style manager</exception>
        public NanoXLSX.Style.Style.Font GetFontByHash(String hash)
        {
            AbstractStyle component = GetComponentByHash(ref fonts, hash);
            if (component == null)
            {
                throw new StyleException("MissingReferenceException", "The style component with the hash '" + hash + "' was not found");
            }
            return (NanoXLSX.Style.Style.Font)component;
        }

        /// <summary>
        /// Gets all fonts of the style manager
        /// </summary>
        /// <returns>Array of fonts</returns>
        public NanoXLSX.Style.Style.Font[] GetFonts()
        {
            return Array.ConvertAll(fonts.ToArray(), x => (NanoXLSX.Style.Style.Font)x);
        }

        /// <summary>
        /// Gets the number of fonts in the style manager
        /// </summary>
        /// <returns>Number of stored fonts</returns>
        public int GetFontStyleNumber()
        {
            return fonts.Count;
        }

        /* ****************************** */

        /// <summary>
        /// Gets a numberFormat by its hash
        /// </summary>
        /// <param name="hash">Hash of the numberFormat</param>
        /// <returns>Determined numberFormat</returns>
        /// <exception cref="StyleException">Throws a StyleException if the numberFormat was not found in the style manager</exception>
        public NanoXLSX.Style.Style.NumberFormat GetNumberFormatByHash(String hash)
        {
            AbstractStyle component = GetComponentByHash(ref numberFormats, hash);
            if (component == null)
            {
                throw new StyleException("MissingReferenceException", "The style component with the hash '" + hash + "' was not found");
            }
            return (NanoXLSX.Style.Style.NumberFormat)component;
        }

        /// <summary>
        /// Gets all numberFormats of the style manager
        /// </summary>
        /// <returns>Array of numberFormats</returns>
        public NanoXLSX.Style.Style.NumberFormat[] GetNumberFormats()
        {
            return Array.ConvertAll(numberFormats.ToArray(), x => (NanoXLSX.Style.Style.NumberFormat)x);
        }

        /// <summary>
        /// Gets the number of numberFormats in the style manager
        /// </summary>
        /// <returns>Number of stored numberFormats</returns>
        public int GetNumberFormatStyleNumber()
        {
            return numberFormats.Count;
        }

        /* ****************************** */

        /// <summary>
        /// Gets a style by its name
        /// </summary>
        /// <param name="name">Name of the style</param>
        /// <returns>Determined style</returns>
        /// <exception cref="StyleException">Throws a StyleException if the style was not found in the style manager</exception>
        public NanoXLSX.Style.Style GetStyleByName(string name)
        {
            int len = styles.Count;
            for (int i = 0; i < len; i++)
            {
                if (((NanoXLSX.Style.Style)styles[i]).Name == name)
                {
                    return (NanoXLSX.Style.Style)styles[i];
                }
            }
            throw new StyleException("MissingReferenceException", "The style with the name '" + name + "' was not found");
        }

        /// <summary>
        /// Gets a style by its hash
        /// </summary>
        /// <param name="hash">Hash of the style</param>
        /// <returns>Determined style</returns>
        /// <exception cref="StyleException">Throws a StyleException if the style was not found in the style manager</exception>
        public NanoXLSX.Style.Style GetStyleByHash(String hash)
        {
            AbstractStyle component = GetComponentByHash(ref styles, hash);
            if (component == null)
            {
                throw new StyleException("MissingReferenceException", "The style component with the hash '" + hash + "' was not found");
            }
            return (NanoXLSX.Style.Style)component;
        }

        /// <summary>
        /// Gets all styles of the style manager
        /// </summary>
        /// <returns>Array of styles</returns>
        public NanoXLSX.Style.Style[] GetStyles()
        {
            return Array.ConvertAll(styles.ToArray(), x => (NanoXLSX.Style.Style)x);
        }

        /// <summary>
        /// Gets the number of styles in the style manager
        /// </summary>
        /// <returns>Number of stored styles</returns>
        public int GetStyleNumber()
        {
            return styles.Count;
        }

        /* ****************************** */


        /// <summary>
        /// Adds a style component to the manager
        /// </summary>
        /// <param name="style">Style to add</param>
        /// <returns>Added or determined style in the manager</returns>
        public NanoXLSX.Style.Style AddStyle(NanoXLSX.Style.Style style)
        {
            string hash = AddStyleComponent(style);
            return (NanoXLSX.Style.Style)GetComponentByHash(ref styles, hash);
        }

        /// <summary>
        /// Adds a style component to the manager with an ID
        /// </summary>
        /// <param name="style">Component to add</param>
        /// <param name="id">Id of the component</param>
        /// <returns>Hash of the added or determined component</returns>
        private string AddStyleComponent(AbstractStyle style, int? id)
        {
            style.InternalID = id;
            return AddStyleComponent(style);
        }

        /// <summary>
        /// Adds a style component to the manager
        /// </summary>
        /// <param name="style">Component to add</param>
        /// <returns>Hash of the added or determined component</returns>
        private string AddStyleComponent(AbstractStyle style)
        {
            string hash = style.Hash;
            if (style.GetType() == typeof(NanoXLSX.Style.Style.Border))
            {
                if (GetComponentByHash(ref borders, hash) == null) { borders.Add(style); }
                Reorganize(ref borders);
            }
            else if (style.GetType() == typeof(NanoXLSX.Style.Style.CellXf))
            {
                if (GetComponentByHash(ref cellXfs, hash) == null) { cellXfs.Add(style); }
                Reorganize(ref cellXfs);
            }
            else if (style.GetType() == typeof(NanoXLSX.Style.Style.Fill))
            {
                if (GetComponentByHash(ref fills, hash) == null) { fills.Add(style); }
                Reorganize(ref fills);
            }
            else if (style.GetType() == typeof(NanoXLSX.Style.Style.Font))
            {
                if (GetComponentByHash(ref fonts, hash) == null) { fonts.Add(style); }
                Reorganize(ref fonts);
            }
            else if (style.GetType() == typeof(NanoXLSX.Style.Style.NumberFormat))
            {
                if (GetComponentByHash(ref numberFormats, hash) == null) { numberFormats.Add(style); }
                Reorganize(ref numberFormats);
            }
            else if (style.GetType() == typeof(NanoXLSX.Style.Style))
            {
                NanoXLSX.Style.Style s = (NanoXLSX.Style.Style)style;
                if (styleNames.Contains(s.Name) == true)
                {
                    throw new StyleException("StyleAlreadyExistsException", "The style with the name '" + s.Name + "' already exists");
                }
                if (GetComponentByHash(ref styles, hash) == null)
                {
                    int? id;
                    if (s.InternalID.HasValue == false)
                    {
                        id = int.MaxValue;
                        s.InternalID = id;
                    }
                    else
                    {
                        id = s.InternalID.Value;
                    }
                    string temp = AddStyleComponent(s.CurrentBorder, id);
                    s.CurrentBorder = (NanoXLSX.Style.Style.Border)GetComponentByHash(ref borders, temp);
                    temp = AddStyleComponent(s.CurrentCellXf, id);
                    s.CurrentCellXf = (NanoXLSX.Style.Style.CellXf)GetComponentByHash(ref cellXfs, temp);
                    temp = AddStyleComponent(s.CurrentFill, id);
                    s.CurrentFill = (NanoXLSX.Style.Style.Fill)GetComponentByHash(ref fills, temp);
                    temp = AddStyleComponent(s.CurrentFont, id);
                    s.CurrentFont = (NanoXLSX.Style.Style.Font)GetComponentByHash(ref fonts, temp);
                    temp = AddStyleComponent(s.CurrentNumberFormat, id);
                    s.CurrentNumberFormat = (NanoXLSX.Style.Style.NumberFormat)GetComponentByHash(ref numberFormats, temp);
                    styles.Add(s);
                }
                Reorganize(ref styles);
                hash = s.CalculateHash();
            }
            return hash;
        }

        /// <summary>
        /// Removes a style and all its components from the style manager
        /// </summary>
        /// <param name="styleName">Name of the style to remove</param>
        /// <exception cref="StyleException">Throws a StyleException if the style was not found in the style manager</exception>
        public void RemoveStyle(string styleName)
        {
            //            string hash = null;
            bool match = false;
            int len = styles.Count;
            int index = -1;
            for (int i = 0; i < len; i++)
            {
                if (((NanoXLSX.Style.Style)styles[i]).Name == styleName)
                {
                    match = true;
                    //                    hash = ((Style)styles[i]).Hash;
                    index = i;
                    break;
                }
            }
            if (match == false)
            {
                throw new StyleException("MissingReferenceException", "The style with the name '" + styleName + "' was not found in the style manager");
            }
            styles.RemoveAt(index);
            CleanupStyleComponents();
        }

        /// <summary>
        /// Method to reorganize / reorder a list of style components
        /// </summary>
        /// <param name="list">List to reorganize as reference</param>
        private void Reorganize(ref List<AbstractStyle> list)
        {
            int len = list.Count;
            list.Sort();
            int id = 0;
            for (int i = 0; i < len; i++)
            {
                list[i].InternalID = id;
                id++;
            }
        }

        /// <summary>
        /// Method to cleanup style components in the style manager
        /// </summary>
        private void CleanupStyleComponents()
        {
            NanoXLSX.Style.Style.Border border;
            NanoXLSX.Style.Style.CellXf cellXf;
            NanoXLSX.Style.Style.Fill fill;
            NanoXLSX.Style.Style.Font font;
            NanoXLSX.Style.Style.NumberFormat numberFormat;
            int len = borders.Count;
            int i;
            for (i = len; i >= 0; i--)
            {
                border = (NanoXLSX.Style.Style.Border)borders[i];
                if (IsUsedByStyle(border) == false) { borders.RemoveAt(i); }
            }
            len = cellXfs.Count;
            for (i = len; i >= 0; i--)
            {
                cellXf = (NanoXLSX.Style.Style.CellXf)cellXfs[i];
                if (IsUsedByStyle(cellXf) == false) { cellXfs.RemoveAt(i); }
            }
            len = fills.Count;
            for (i = len; i >= 0; i--)
            {
                fill = (NanoXLSX.Style.Style.Fill)fills[i];
                if (IsUsedByStyle(fill) == false) { fills.RemoveAt(i); }
            }
            len = fonts.Count;
            for (i = len; i >= 0; i--)
            {
                font = (NanoXLSX.Style.Style.Font)fonts[i];
                if (IsUsedByStyle(font) == false) { fonts.RemoveAt(i); }
            }
            len = numberFormats.Count;
            for (i = len; i >= 0; i--)
            {
                numberFormat = (NanoXLSX.Style.Style.NumberFormat)numberFormats[i];
                if (IsUsedByStyle(numberFormat) == false) { numberFormats.RemoveAt(i); }
            }
        }

        /// <summary>
        /// Checks whether a style component in the style manager is used by a style
        /// </summary>
        /// <param name="component">Component to check</param>
        /// <returns>If true, the component is in use</returns>
        private bool IsUsedByStyle(AbstractStyle component)
        {
            NanoXLSX.Style.Style s;
            bool match = false;
            String hash = component.Hash;
            int len = styles.Count;
            for (int i = 0; i < len; i++)
            {
                s = (NanoXLSX.Style.Style)styles[i];
                if (component.GetType() == typeof(NanoXLSX.Style.Style.Border)) { if (s.CurrentBorder.Hash == hash) { match = true; break; } }
                else if (component.GetType() == typeof(NanoXLSX.Style.Style.CellXf)) { if (s.CurrentCellXf.Hash == hash) { match = true; break; } }
                if (component.GetType() == typeof(NanoXLSX.Style.Style.Fill)) { if (s.CurrentFill.Hash == hash) { match = true; break; } }
                if (component.GetType() == typeof(NanoXLSX.Style.Style.Font)) { if (s.CurrentFont.Hash == hash) { match = true; break; } }
                if (component.GetType() == typeof(NanoXLSX.Style.Style.NumberFormat)) { if (s.CurrentNumberFormat.Hash == hash) { match = true; break; } }
            }
            return match;
        }



        #endregion
    }

}