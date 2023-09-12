using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.Entites.Models;
using Project.WinFormUi.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinFormUi
{
    public partial class Form1 : Form
    {
        CategoryRepository _categoryRepository;

        public Form1()
        {
            InitializeComponent();
            _categoryRepository = new CategoryRepository();
        }

        void ListCategories()
        {
            lstCategories.DataSource = _categoryRepository.CustomSelect(x => new CategoryVM
            {

                ID = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Products = x.Products,
            }).ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListCategories();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Lütfen Kategori İsmi Giriniz...");
                return;
            }

            Category c = new Category()
            {
                CategoryName = txtName.Text,
                Description = txtDescription.Text,
            };

            _categoryRepository.Add(c);
            ListCategories();
        }

        CategoryVM _selected;

        private void lstCategories_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedIndex > -1)
            {
                _selected = (CategoryVM)lstCategories.SelectedItem;
                txtName.Text = _selected.CategoryName;
                txtDescription.Text = _selected.Description;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected != null) 
            {
                Category toBeDeletedCategory = _categoryRepository.Find(_selected.ID);
                _categoryRepository.Delete(toBeDeletedCategory);
                ListCategories();
                _selected = null;
                txtDescription.Text = txtName.Text = null;
            }
            else
            {
                MessageBox.Show("Lütfen Bir Kategori Seçiniz.");
            }
        }

        private void btnForm2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }
    }
}
