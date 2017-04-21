using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlStandardDifferencer
{
    public class TypeNameMappingList
    {
        public static KeyValuePair<String, String>[] DotNetEquivalentMappings = new KeyValuePair<String, String>[]
        {
            new KeyValuePair<String, String>("System.DateTime", "System.DateTimeOffset"),
        };

        public static KeyValuePair<String, String>[] UXPXamlToXamarinFormsMappings = new KeyValuePair<String, String>[]
        {
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.StackPanel", "Xamarin.Forms.StackLayout"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.RelativePanel", "Xamarin.Forms.RelativeLayout"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.TextBox", "Xamarin.Forms.Entry"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.RichEditBox", "Xamarin.Forms.Editor"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.ProgressRing", "Xamarin.Forms.ActivityIndicator"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.ComboBox", "Xamarin.Forms.Picker"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.ScrollViewer", "Xamarin.Forms.ScrollView"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.Canvas", "Xamarin.Forms.AbsoluteLayout"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.TextBlock", "Xamarin.Forms.Label"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.Border", "Xamarin.Forms.Frame"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.Page", "Xamarin.Forms.ContentPage"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.FlipView", "Xamarin.Forms.CarouselView"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.ToggleSwitch", "Xamarin.Forms.Switch"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.Pivot", "Xamarin.Forms.TabbedPage"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.AutoSuggestBox", "Xamarin.Forms.SearchBar"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.DependencyProperty", "Xamarin.Forms.BindableProperty"),
            new KeyValuePair<String, String>("Windows.UI.Xaml.Controls.Orientation", "Xamarin.Forms.StackOrientation"),
        };

        private Dictionary<String, String> _mappings = new Dictionary<String, String>(StringComparer.InvariantCultureIgnoreCase);
        private Dictionary<String, String> _inverseMappings = new Dictionary<String, String>(StringComparer.InvariantCultureIgnoreCase);

        public TypeNameMappingList()
        {
        }

        public bool Add(String first, String second)
        {
            // check for overwrite case
            if (_mappings.ContainsKey(first))
            {
                return false;
            }

            _mappings[first] = second;
            _inverseMappings[second] = first;
            return true;
        }

        public void Add(IEnumerable<KeyValuePair<String, String>> mappings)
        {
            foreach (KeyValuePair<String, String> pair in mappings)
            {
                Add(pair.Key, pair.Value);
            }
        }

        public void Add(IEnumerable<KeyValuePair<TypeDescription, TypeDescription>> mappings)
        {
            foreach (KeyValuePair<TypeDescription, TypeDescription> pair in mappings)
            {
                Add(pair.Key.FullName, pair.Value.FullName);
            }
        }

        public String GetMappedTypeName(String typeName)
        {
            if (_mappings.ContainsKey(typeName))
            {
                return _mappings[typeName];
            }
            if (_inverseMappings.ContainsKey(typeName))
            {
                return _inverseMappings[typeName];
            }
            return null;
        }

        public bool AreEquivalent(TypeDescription typeFirst, TypeDescription typeSecond)
        {
            return AreEquivalent(typeFirst.FullName, typeSecond.FullName);
        }

        public bool AreEquivalent(String typeNameFirst, String typeNameSecond)
        {
            if (typeNameFirst == null)
            {
                return typeNameSecond == null;
            }

            if (typeNameSecond == null)
            {
                return typeNameFirst == null;
            }

            if (typeNameFirst.Equals(typeNameSecond, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            String mapping = GetMappedTypeName(typeNameFirst);
            return mapping != null && mapping.Equals(typeNameSecond, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
