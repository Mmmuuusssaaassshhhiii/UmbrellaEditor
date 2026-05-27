using System.ComponentModel;
using UmbrellaCore;
using UmbrellaCore.Entities;
using UmbrellaCore.Factories;
using UmbrellaCore.Interfaces;
using UmbrellaCore.Services;

namespace UmbrellaEditor;

public partial class MainForm : Form
{
    // ДАННЫЕ
    private BindingList<UmbrellaEntity> entities =
        new BindingList<UmbrellaEntity>();

    private PluginContext pluginContext =
        new PluginContext();

    // UI
    private ListBox listBoxEntities;
    private PropertyGrid propertyGrid1;

    private Button buttonAdd;
    private Button buttonDelete;
    private Button buttonSave;
    private Button buttonLoad;

    private ComboBox comboBoxFactories;

    private Label labelObjects;
    private Label labelProperties;
    private Label labelFactory;

    // КОНСТРУКТОР
    public MainForm()
    {
        InitializeComponent();

        Load += MainForm_Load;
    }

    // СОЗДАНИЕ UI
    private void InitializeComponent()
    {
        // FORM
        Text = "Umbrella Laboratory Editor";

        Width = 1200;
        Height = 700;

        StartPosition = FormStartPosition.CenterScreen;

        BackColor = Color.FromArgb(30, 30, 30);
        ForeColor = Color.White;

        Font = new Font("Segoe UI", 10);

        // LABEL OBJECTS
        labelObjects = new Label();

        labelObjects.Text = "Objects";

        labelObjects.Left = 20;
        labelObjects.Top = 15;

        labelObjects.Width = 200;

        labelObjects.Font =
            new Font("Segoe UI", 12, FontStyle.Bold);

        Controls.Add(labelObjects);

        // LISTBOX
        listBoxEntities = new ListBox();

        listBoxEntities.Left = 20;
        listBoxEntities.Top = 50;

        listBoxEntities.Width = 400;
        listBoxEntities.Height = 500;

        listBoxEntities.BackColor =
            Color.FromArgb(45, 45, 45);

        listBoxEntities.ForeColor = Color.White;

        listBoxEntities.BorderStyle =
            BorderStyle.FixedSingle;

        listBoxEntities.SelectedIndexChanged +=
            listBoxEntities_SelectedIndexChanged;

        Controls.Add(listBoxEntities);

        // LABEL PROPERTIES
        labelProperties = new Label();

        labelProperties.Text = "Properties";

        labelProperties.Left = 450;
        labelProperties.Top = 15;

        labelProperties.Width = 200;

        labelProperties.Font =
            new Font("Segoe UI", 12, FontStyle.Bold);

        Controls.Add(labelProperties);

        // PROPERTY GRID
        propertyGrid1 = new PropertyGrid();

        propertyGrid1.Left = 450;
        propertyGrid1.Top = 50;

        propertyGrid1.Width = 700;
        propertyGrid1.Height = 500;

        Controls.Add(propertyGrid1);

        // LABEL FACTORY
        labelFactory = new Label();

        labelFactory.Text = "Entity Type";

        labelFactory.Left = 20;
        labelFactory.Top = 570;

        labelFactory.Width = 200;

        Controls.Add(labelFactory);

        // COMBOBOX
        comboBoxFactories = new ComboBox();

        comboBoxFactories.Left = 20;
        comboBoxFactories.Top = 600;

        comboBoxFactories.Width = 250;

        comboBoxFactories.DropDownStyle =
            ComboBoxStyle.DropDownList;

        comboBoxFactories.BackColor =
            Color.FromArgb(45, 45, 45);

        comboBoxFactories.ForeColor = Color.White;

        Controls.Add(comboBoxFactories);

        // BUTTON ADD
        buttonAdd = CreateButton(
            "Add",
            300,
            600);

        buttonAdd.Click += buttonAdd_Click;

        Controls.Add(buttonAdd);

        // BUTTON DELETE
        buttonDelete = CreateButton(
            "Delete",
            420,
            600);

        buttonDelete.Click += buttonDelete_Click;

        Controls.Add(buttonDelete);

        // BUTTON SAVE
        buttonSave = CreateButton(
            "Save",
            540,
            600);

        buttonSave.Click += buttonSave_Click;

        Controls.Add(buttonSave);

        // BUTTON LOAD
        buttonLoad = CreateButton(
            "Load",
            660,
            600);

        buttonLoad.Click += buttonLoad_Click;

        Controls.Add(buttonLoad);
    }

    // СОЗДАНИЕ КНОПОК
    private Button CreateButton(
        string text,
        int x,
        int y)
    {
        Button button = new Button();

        button.Text = text;

        button.Left = x;
        button.Top = y;

        button.Width = 100;
        button.Height = 40;

        button.FlatStyle = FlatStyle.Flat;

        button.BackColor =
            Color.FromArgb(170, 0, 0);

        button.ForeColor = Color.White;

        return button;
    }

    // ЗАГРУЗКА ФОРМЫ
    private void MainForm_Load(
        object sender,
        EventArgs e)
    {
        // РЕГИСТРАЦИЯ ФАБРИК
        FactoryRegistry.Factories.Add(
            new VirusFactory());

        FactoryRegistry.Factories.Add(
            new MutantFactory());

        FactoryRegistry.Factories.Add(
            new ScientistFactory());

        FactoryRegistry.Factories.Add(
            new SecurityFactory());

        FactoryRegistry.Factories.Add(
            new ExperimentFactory());

        FactoryRegistry.Factories.Add(
            new BioWeaponFactory());

        // ЗАГРУЗКА ПЛАГИНОВ
        PluginLoader.LoadPlugins(
            "Plugins",
            pluginContext);

        // ДОБАВЛЕНИЕ ФАБРИК ПЛАГИНОВ
        foreach (var f in pluginContext.Factories)
        {
            FactoryRegistry.Factories.Add(f);
        }

        // ПРИВЯЗКА СПИСКА
        listBoxEntities.DataSource = entities;

        // ПРИВЯЗКА COMBOBOX
        comboBoxFactories.DataSource =
            FactoryRegistry.Factories;

        comboBoxFactories.DisplayMember =
            "Name";
    }

    // ДОБАВИТЬ
    private void buttonAdd_Click(
        object sender,
        EventArgs e)
    {
        if (comboBoxFactories.SelectedItem
            is IEntityFactory factory)
        {
            UmbrellaEntity entity =
                factory.Create();

            entity.Name = "New Object";

            entities.Add(entity);
        }
    }

    // УДАЛИТЬ
    private void buttonDelete_Click(
        object sender,
        EventArgs e)
    {
        if (listBoxEntities.SelectedItem
            is UmbrellaEntity entity)
        {
            entities.Remove(entity);
        }
    }

    // ВЫБОР ОБЪЕКТА
    private void listBoxEntities_SelectedIndexChanged(
        object sender,
        EventArgs e)
    {
        propertyGrid1.SelectedObject =
            listBoxEntities.SelectedItem;
    }

    // СОХРАНИТЬ
    private void buttonSave_Click(
        object sender,
        EventArgs e)
    {
        SaveFileDialog dialog =
            new SaveFileDialog();

        dialog.Filter = "JSON|*.json";

        if (dialog.ShowDialog()
            == DialogResult.OK)
        {
            JsonStorageService.Save(
                entities.ToList(),
                dialog.FileName);
        }
    }

    // ЗАГРУЗИТЬ
    private void buttonLoad_Click(
        object sender,
        EventArgs e)
    {
        OpenFileDialog dialog =
            new OpenFileDialog();

        dialog.Filter = "JSON|*.json";

        if (dialog.ShowDialog()
            == DialogResult.OK)
        {
            var loaded =
                JsonStorageService.Load(
                    dialog.FileName);

            entities.Clear();

            foreach (var item in loaded)
            {
                entities.Add(item);
            }
        }
    }
}