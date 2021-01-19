﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UassetReaderWithGui.ViewModel.Controls;
using UassetReaderWithGui.ViewModel.Uasset.PropertyTypes;

namespace UassetReaderWithGui.WpfUtil
{
    public class TreeViewDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate result;

            if (   !(container is FrameworkElement element) 
                || item == null 
                || !(item is TreeViewItemViewModel tvItem)
               )
                return base.SelectTemplate(item, container);

            // TODO: determine result
            switch (tvItem.DataItem)
            {
                case StructPropertyViewModel structProperty:
                    result = element.FindResource("ItemTemplateStructProperty") as DataTemplate;
                    break;

                default:
                    result = element.FindResource("ItemTemplateDefault") as DataTemplate;
                    break;
            }

            return result;
        }
    }
}