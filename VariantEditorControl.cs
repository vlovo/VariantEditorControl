using DataTypes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VariantEditorControl

{
    using VariantList = Dictionary<string, Variant>;

    public partial class VariantEditorControl : UserControl
    {
        public VariantEditorControl()
        {
            InitializeComponent();
            CreateTableHeader();



        }

        public void SetDataList(VariantList data, VariantList dataMin, VariantList dataMax, VariantList dataDiscrete)
        {

            mainTable.Controls.Clear();

            CreateTableHeader();

            int rowIndex = 1;

            var size = new System.Drawing.Size(85, 20);

            foreach (var element in data)
            {

                switch (element.Value.getDataType())
                {
                    case Variant.VariantDataType.INTEGER:


                        Label lIntegerName = new Label();
                        lIntegerName.Text = element.Key;
                        mainTable.Controls.Add(lIntegerName, 0, rowIndex);


                        if (dataDiscrete.ContainsKey(element.Key))
                        {
                            ComboBox box = new ComboBox();
                            box.Size = size;
                            box.DataSource = dataDiscrete[element.Key].getIntList();
                            box.SelectedIndexChanged += (s, e) =>
                            {
                                element.Value.setInt(System.Convert.ToInt32((s as ComboBox).SelectedItem));
                            };


                            mainTable.Controls.Add(box, 1, rowIndex);
                        }
                        else
                        {
                            NumericUpDown updwn = new NumericUpDown();
                            updwn.Size = size;
                            updwn.Minimum = dataMin.ContainsKey(element.Key) ? (int)dataMin[element.Key].getInt() : 0;
                            updwn.Maximum = dataMax.ContainsKey(element.Key) ? (int)dataMax[element.Key].getInt() : (int)element.Value.getInt() * 2; ;

                            updwn.DataBindings.Add("Value", new VariantBindingProperties(element.Value), "asInteger");
                            mainTable.Controls.Add(updwn, 1, rowIndex);



                        }
                        Label lIntegerUnit = new Label();
                        lIntegerUnit.Text = element.Value.getUnit();
                        mainTable.Controls.Add(lIntegerUnit, 2, rowIndex);

                        lIntegerUnit.Anchor = AnchorStyles.Left;
                        mainTable.RowStyles[rowIndex].SizeType = SizeType.AutoSize;
                        ++rowIndex;


                        break;


                    case Variant.VariantDataType.DOUBLE:


                        Label lDoubleName = new Label();
                        lDoubleName.Text = element.Key;
                        mainTable.Controls.Add(lDoubleName, 0, rowIndex);


                        NumericUpDown updwn1 = new NumericUpDown();
                        updwn1.Size = size;
                        updwn1.DecimalPlaces = 2;
                        updwn1.Increment = 0.1M;
                        updwn1.Minimum = dataMin.ContainsKey(element.Key) ? (int)dataMin[element.Key].getDouble() : 0;
                        updwn1.Maximum = dataMax.ContainsKey(element.Key) ? (int)dataMax[element.Key].getDouble() : (int)element.Value.getDouble() * 2; ;


                        updwn1.DataBindings.Add("Value", new VariantBindingProperties(element.Value), "asDouble");
                        mainTable.Controls.Add(updwn1, 1, rowIndex);

                        Label lDoubleUnit = new Label();
                        lDoubleUnit.Text = element.Value.getUnit();
                        lDoubleUnit.Anchor = AnchorStyles.Left;

                        mainTable.Controls.Add(lDoubleUnit, 2, rowIndex);
                        mainTable.RowStyles[rowIndex].SizeType = SizeType.AutoSize;
                        ++rowIndex;

                        break;



                    case Variant.VariantDataType.STRING:


                        Label lStringName = new Label();
                        lStringName.Text = element.Key;
                        mainTable.Controls.Add(lStringName, 0, rowIndex);

                        if (dataDiscrete.ContainsKey(element.Key))
                        {
                            ComboBox box = new ComboBox();
                            box.Size = size;
                            box.DataSource = dataDiscrete[element.Key].getStringList();
                            box.SelectedIndexChanged += (s, e) =>
                            {
                                element.Value.setString((string)(s as ComboBox).SelectedItem);
                            };


                            mainTable.Controls.Add(box, 1, rowIndex);
                        }
                        else
                        {
                            TextBox box = new TextBox();
                            box.Size = size;
                            box.DataBindings.Add("Text", new VariantBindingProperties(element.Value), "asString");

                            mainTable.Controls.Add(box, 1, rowIndex);
                        }




                        Label lStringUnit = new Label();
                        lStringUnit.Text = element.Value.getUnit();
                        lStringUnit.Anchor = AnchorStyles.Left;

                        mainTable.Controls.Add(lStringUnit, 2, rowIndex);
                        mainTable.RowStyles[rowIndex].SizeType = SizeType.AutoSize;

                        ++rowIndex;
                        break;


                    case Variant.VariantDataType.BOOL:
                        Label lBoolName = new Label();
                        lBoolName.Text = element.Key;
                        mainTable.Controls.Add(lBoolName, 0, rowIndex);

                        CheckBox chbox = new CheckBox();
                        chbox.Size = size;
                        chbox.DataBindings.Add("Checked", new VariantBindingProperties(element.Value), "asBool");

                        mainTable.Controls.Add(chbox, 1, rowIndex);

                        Label lBoolUnit = new Label();
                        lBoolUnit.Text = element.Value.getUnit();
                        lBoolUnit.Anchor = AnchorStyles.Left;

                        mainTable.Controls.Add(lBoolUnit, 2, rowIndex);
                        mainTable.RowStyles[rowIndex].SizeType = SizeType.AutoSize;
                        ++rowIndex;

                        break;

                    case Variant.VariantDataType.STRINGLIST:
                        Label l5 = new Label();
                        l5.Text = element.Key;
                        mainTable.Controls.Add(l5, 0, rowIndex);

                        ComboBox lbox = new ComboBox();
                        lbox.Size = size;
                        lbox.DataSource = new VariantBindingProperties(element.Value).asStringList;
                        mainTable.Controls.Add(lbox, 1, rowIndex);

                        Label lStringListUnit = new Label();
                        lStringListUnit.Text = element.Value.getUnit();
                        mainTable.Controls.Add(lStringListUnit, 2, rowIndex);
                        mainTable.RowStyles[rowIndex].SizeType = SizeType.AutoSize;
                        ++rowIndex;
                        break;

                    default:
                        break;

                }

            }

            return;
        }



        private void CreateTableHeader()
        {
            const int rowIndex = 0;
            Label l00 = new Label();
            l00.Text = "Name";
            l00.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            Label l10 = new Label();
            l10.Text = "Value";
            l10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            Label l20 = new Label();
            l20.Anchor = AnchorStyles.Left;
            l20.Text = "Unit";

            l20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            mainTable.Controls.Add(l00, 0, rowIndex);
            mainTable.Controls.Add(l10, 1, rowIndex);
            mainTable.Controls.Add(l20, 2, rowIndex);
            mainTable.RowStyles[rowIndex].SizeType = SizeType.AutoSize;
            return;
        }
    }
}
