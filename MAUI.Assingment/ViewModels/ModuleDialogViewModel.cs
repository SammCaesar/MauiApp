using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.Assignment1.Entities;
using Library.Assignment1.Services;

namespace MAUI.Assingment.ViewModels
{
    public class ModuleDialogViewModel
    {
        private CourseService courseSvc;
        private Module? module;
        private ContentItem? contentItem;
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Name
        {
            get { return module?.Name ?? string.Empty; }
            set
            {
                if (module == null) module = new Module();
                module.Name = value;
            }
        }
        public string Description
        {
            get { return module?.Description ?? string.Empty; }
            set
            {
                if (module == null) module = new Module();
                module.Description = value;
            }
        }
        public string ContentItemName
        {
            get { return contentItem?.Name ?? string.Empty; }
            set
            {
                if (contentItem == null) contentItem = new ContentItem();
                contentItem.Name = value;
            }
        }
        public string ContentItemDescription
        {
            get { return contentItem?.Description ?? string.Empty; }
            set
            {
                if (contentItem == null) contentItem = new ContentItem();
                contentItem.Description = value;
            }
        }
        public Course SelectedCourse
        {
            get; set;
        }
        public ModuleDialogViewModel()
        {
            courseSvc = CourseService.Current;
            module = new Module();
            contentItem = new ContentItem();
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Courses));
        }
        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(courseSvc.Courses);
            }
        }
        public void AddModule()
        {
            if (module != null && contentItem != null)
            {
                module.Content.Add(contentItem);
                SelectedCourse.Modules.Add(module);
                RefreshView();
            }
        }
    }
}
