using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Demo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Demo.ViewModels
{

    public partial class TaskViewModel : ObservableObject
    {
        public ObservableCollection<Model.TaskModel> TaskList { get; set; } = new ObservableCollection<Model.TaskModel>();

        private List<Model.TaskModel> _allTaskList = new List<Model.TaskModel>();

        private Model.TaskModel _draggedItem;

        [ObservableProperty]
        private int _NewTaskCount;

        [ObservableProperty]
        private int _inProgressCount;

        [ObservableProperty]
        private int _inReviewCount;

        [ObservableProperty]
        private int _doneCount;

        [ObservableProperty]
        private int _selectedOption;

        [ObservableProperty]
        private bool _isBusy;

        public TaskViewModel()
        {
            try
            {
                BindModelTaskData();
                AddTaskList();
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        public void BindModelTaskData()
        {
            try
            {
                _allTaskList.Add(new Model.TaskModel() { TaskName = "Task 1", TaskStatus = (int)TaskStatusOption.NewTask, TaskId = 1 });
                _allTaskList.Add(new Model.TaskModel() { TaskName = "Task 2", TaskStatus = (int)TaskStatusOption.NewTask, TaskId = 2 });
                _allTaskList.Add(new Model.TaskModel() { TaskName = "Task 3", TaskStatus = (int)TaskStatusOption.NewTask, TaskId = 3 });

                _allTaskList.Add(new Model.TaskModel() { TaskName = "Task 4", TaskStatus = (int)TaskStatusOption.InProgress, TaskId = 4 });
                _allTaskList.Add(new Model.TaskModel() { TaskName = "Task 5", TaskStatus = (int)TaskStatusOption.InProgress, TaskId = 5 });

                _allTaskList.Add(new Model.TaskModel() { TaskName = "Task 6", TaskStatus = (int)TaskStatusOption.InReview, TaskId = 6 });
                _allTaskList.Add(new Model.TaskModel() { TaskName = "Task 7", TaskStatus = (int)TaskStatusOption.InReview, TaskId = 7 });

                _allTaskList.Add(new Model.TaskModel() { TaskName = "Task 8", TaskStatus = (int)TaskStatusOption.Done, TaskId = 8 });
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void AddTaskList()
        {
            try
            {
                var filterTaskList = _allTaskList.Where(x => x.TaskStatus == SelectedOption).ToList();

                TaskList.Clear();
                foreach (var task in filterTaskList)
                {
                    TaskList.Add(task);
                }

                SetCount();
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void SetCount()
        {
            try
            {
                NewTaskCount = _allTaskList.Count(x => x.TaskStatus == (int)TaskStatusOption.NewTask);
                InProgressCount = _allTaskList.Count(x => x.TaskStatus == (int)TaskStatusOption.InProgress);
                InReviewCount = _allTaskList.Count(x => x.TaskStatus == (int)TaskStatusOption.InReview);
                DoneCount = _allTaskList.Count(x => x.TaskStatus == (int)TaskStatusOption.Done);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        [RelayCommand]
        public void FilterTaskList(string optionStr)
        {
            try
            {
                int option = Convert.ToInt32(optionStr);
                SelectedOption = -1;
                SelectedOption = option;
                AddTaskList();
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        [RelayCommand]
        public void DragStarted(Model.TaskModel task)
        {
            _draggedItem = task;
        }

        [RelayCommand]
        public async void TaskDroped(string optionStr)
        {
            try
            {
                int option = Convert.ToInt32(optionStr);
                if (SelectedOption == option) return;

                IsBusy = true;
                await System.Threading.Tasks.Task.Delay(500);

                if (_draggedItem != null)
                {
                    var currentItem = _allTaskList.Where(x => x.TaskId == _draggedItem.TaskId).FirstOrDefault();
                    currentItem.TaskStatus = option;

                    AddTaskList();
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }
    }
}
