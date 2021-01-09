using MetroFramework.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroFramework.Winform
{
    /// <summary>
    /// An MetroFramework ComboBox
    /// </summary>
    public class MetroFrameworkComboBox: MetroComboBox, MetroFrameworkControl
    {
        /// <summary>
        /// The array of <see cref="MetroFrameworkComboObject"/> in this <see cref="MetroFrameworkComboBox"/>
        /// </summary>
        public MetroFrameworkComboObjectCollection Objects
        {
            get
            {
                return comboObjects;
            }
            set
            {
                foreach(var obj in value.OrderBy(x => x.Index))
                {
                    comboObjects.Add(obj);       
                    ItemsShown.Add(obj.Text);
                }
                Items.Clear();
                Items.AddRange(ItemsShown.ToArray());
            }
        }

        /// <summary>
        /// The value of this <see cref="MetroFrameworkComboBox"/>
        /// </summary>
        public string Value {
            get
            {
                return _value;
            }
            set 
            {
                if(Objects.Length > 0)
                {
                    bool HadValue = false;
                    foreach(var obj in Objects)
                    {
                        if(obj.Value == value)
                        {
                            SelectedIndex = obj.Index;
                            HadValue = true;
                            break;
                        }
                    }
                    if (!HadValue)
                    {
                        SelectedIndex = -1;
                    }
                }
                else
                {
                    Text = value;
                }
            }
        }

        private string _value;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Required { get; set; } = false;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ErrorProvider ErrorProvider { get; set; } = new ErrorProvider();

        private MetroFrameworkComboObjectCollection comboObjects = new MetroFrameworkComboObjectCollection();

        private List<string> ItemsShown = new List<string>();
        /// <summary>
        /// An MetroFramework ComboBox
        /// </summary>
        public MetroFrameworkComboBox()
        {
            if(!DesignMode)
            StyleManager = MetroFrameworkBuffer.Instance.Manager;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void OnSelectedItemChanged(EventArgs e)
        {
            base.OnSelectedItemChanged(e);
            Text = Objects.ToArray()[SelectedIndex].Text;
            _value = Objects.ToArray()[SelectedIndex].Value;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void OnSelectedValueChanged(EventArgs e)
        {
            base.OnSelectedValueChanged(e);
            Text = Objects.ToArray()[SelectedIndex].Text;
            _value = Objects.ToArray()[SelectedIndex].Value;
        }
        
        /// <summary>
        /// Check if user selected a Value in <see cref="MetroFrameworkComboBox"/>
        /// </summary>
        /// <returns></returns>
        public bool HasValue()
        {
            if(Objects.Count() < 1)
            {
                //No Objects
                return !string.IsNullOrEmpty(Text);
            }
            return !string.IsNullOrEmpty(_value) && Objects.Any(x => x.Text == _value);
        }
        /// <summary>
        /// The <see cref="ComboBox"/>'s Items for <see cref="MetroFrameworkComboBox"/>
        /// </summary>
        public class MetroFrameworkComboObject:object
        {
            /// <summary>
            /// The Text to be shown
            /// </summary>
            public string Text { get; set; }
            /// <summary>
            /// The Value for saving 
            /// </summary>
            public string Value { get; set; }
            /// <summary>
            /// The ordering for MetroFrameworkComboObject
            /// </summary>
            public int Index { get; set; } = 0;
        }
        /// <summary>
        /// A collection of <see cref="MetroFrameworkComboObject"/>
        /// </summary>
        public class MetroFrameworkComboObjectCollection : IEnumerable<MetroFrameworkComboObject>
        {
            private List<MetroFrameworkComboObject> objects;
            /// <summary>
            /// <inheritdoc/>
            /// </summary>
            public MetroFrameworkComboObjectCollection()
            {
                objects = new List<MetroFrameworkComboObject>();
            }
            /// <summary>
            /// Returns the number of elements in a sequence
            /// </summary>
            public int Length
            {
                get
                {
                    return objects.Count();
                }
            }
            /// <summary>
            /// <inheritdoc/>
            /// </summary>
            public IEnumerator<MetroFrameworkComboObject> GetEnumerator()
            {
                return objects.GetEnumerator();
            }
            /// <summary>
            /// <inheritdoc/>
            /// </summary>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            /// <summary>
            /// Add an <see cref="MetroFrameworkComboObject"/>
            /// </summary>
            /// <param name="obj"></param>
            public void Add(MetroFrameworkComboObject obj)
            {
                if (!objects.Contains(obj))
                {
                    if(obj.Index == 0 && objects.Count > 0)
                    {
                        obj.Index = objects.Count;
                    }
                    objects.Add(obj);
                }
            }

            /// <summary>
            /// Add an <see cref="MetroFrameworkComboObject"/>
            /// </summary>
            /// <param name="input"></param>
            /// <param name="index"></param>
            public void Add(KeyValuePair<string, string> input, int? index = null)
            {
                Add(input.Key, input.Value, index);
            }
            /// <summary>
            /// Add an <see cref="MetroFrameworkComboObject"/>
            /// </summary>
            /// <param name="Text"></param>
            /// <param name="index"></param>
            public void Add(string Text, int? index = null)
            {
                Add(Text, Text, index);
            }

            /// <summary>
            /// Add an <see cref="MetroFrameworkComboObject"/>
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            /// <param name="index"></param>
            public void Add(string key, string value, int? index = null)
            {
                MetroFrameworkComboObject obj = new MetroFrameworkComboObject()
                {
                    Text = key,
                    Value = value
                };
                if (index.HasValue)
                {
                    obj.Index = index.Value;
                }
                Add(obj);
            }

            /// <summary>
            /// Remove the object from <see cref="MetroFrameworkComboBox"/> list
            /// </summary>
            public void Remove(KeyValuePair<string, string> input)
            {
                var result = objects.Where(x => x.Text == input.Key && x.Value == input.Value);
                if(result.Count() > 0)
                {
                    foreach(var r in result)
                    {
                        objects.Remove(r);
                    }
                }
            }

            /// <summary>
            /// Remove the object from <see cref="MetroFrameworkComboBox"/> list
            /// </summary>
            public void Remove(string key)
            {
                var result = objects.Where(x => x.Text == key);
                if (result.Count() > 0)
                {
                    foreach (var r in result)
                    {
                        objects.Remove(r);
                    }
                }
            }

            /// <summary>
            /// Remove the object from <see cref="MetroFrameworkComboBox"/> list
            /// </summary>
            public void Remove(MetroFrameworkComboObject obj)
            {
                if (objects.Contains(obj))
                {
                    objects.Remove(obj);
                }
                else
                {
                    var filter = objects.Where(x => x.Text == obj.Text && x.Value == obj.Value).ToArray();
                    if (filter.Length > 0)
                    {
                        foreach (var o in filter)
                        {
                            objects.Remove(o);
                        }
                    }
                }
            }
        }
    }
}
