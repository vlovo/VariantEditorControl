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

        public void SetDataList(VariantList data, VariantList dataDiscrete)
        {
            int rowIndex = 1;

            var size = new System.Drawing.Size(85, 20);
            mainTable.Controls.Clear();
            foreach (var element in data)
            {

                switch (element.Value.getDataType())
                {
                    case Variant.VariantDataType.INTEGER:
                        Label l0 = new Label();
                        l0.Text = element.Key;
                        mainTable.Controls.Add(l0, 0, rowIndex);


                        if (dataDiscrete.ContainsKey(element.Key))
                        {
                            ComboBox box = new ComboBox();
                            box.Size = size;
                            box.DataSource = dataDiscrete[element.Key].getIntList();
                            box.SelectedIndexChanged += (s, e) =>
                            {
                                element.Value.setInt((int)(s as ComboBox).SelectedItem);
                            };


                            mainTable.Controls.Add(box, 1, rowIndex);
                        }
                        else
                        {
                            NumericUpDown updwn = new NumericUpDown();
                            updwn.Size = size;
                            updwn.DataBindings.Add("Value", new VariantBindingProperties(element.Value), "asInteger");
                            mainTable.Controls.Add(updwn, 1, rowIndex);
                        }
                        Label l00 = new Label();
                        l00.Text = element.Value.getUnit();
                        mainTable.Controls.Add(l00, 2, rowIndex);

                        ++rowIndex;

                        break;


                    case Variant.VariantDataType.DOUBLE:
                        Label l1 = new Label();
                        l1.Text = element.Key;
                        mainTable.Controls.Add(l1, 0, rowIndex);


                        Panel p = new Panel();
                        p.AutoSize = true;
                        p.BorderStyle = BorderStyle.None;
                        TrackBar tr = new TrackBar();

                        tr.Maximum = (int)element.Value.getDouble() * 2;
                        tr.Minimum = 0;
                        tr.Size = size;
                        tr.TickStyle = TickStyle.None;
                        tr.Location = new System.Drawing.Point(0, 22);
                        tr.DataBindings.Add("Value", new VariantBindingProperties(element.Value), "asDouble");

                        //tableLayoutPanel1.Controls.Add(tr, 1, rowIndex);

                        TextBox b = new TextBox();
                        b.Size = size;
                        b.DataBindings.Add("Text", tr, "Value");
                        p.Controls.Add(b);


                        p.Controls.Add(tr);

                        mainTable.Controls.Add(p, 1, rowIndex);

                        Label l11 = new Label();
                        l11.Text = element.Value.getUnit();
                        mainTable.Controls.Add(l11, 2, rowIndex);

                        ++rowIndex;
                        break;



                    case Variant.VariantDataType.STRING:


                        Label l3 = new Label();
                        l3.Text = element.Key;
                        mainTable.Controls.Add(l3, 0, rowIndex);

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






                        Label unitl4 = new Label();
                        unitl4.Text = element.Value.getUnit();
                        mainTable.Controls.Add(unitl4, 2, rowIndex);


                        ++rowIndex;
                        break;


                    case Variant.VariantDataType.BOOL:
                        Label l7 = new Label();
                        l7.Text = element.Key;
                        mainTable.Controls.Add(l7, 0, rowIndex);

                        CheckBox chbox = new CheckBox();
                        chbox.Size = size;
                        chbox.DataBindings.Add("Checked", new VariantBindingProperties(element.Value), "asBool");
                        mainTable.Controls.Add(chbox, 1, rowIndex);

                        Label l8 = new Label();
                        l8.Text = "none";

                        mainTable.Controls.Add(l8, 2, rowIndex);

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

                        Label l6 = new Label();
                        l6.Text = element.Value.getUnit();
                        mainTable.Controls.Add(l6, 2, rowIndex);
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

            return;
        }
    }
}
