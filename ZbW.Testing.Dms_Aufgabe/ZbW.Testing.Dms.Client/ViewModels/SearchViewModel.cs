using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Repositories;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    internal class SearchViewModel : BindableBase
    {
        private readonly LoadFileRepository _loadFileRepository;
        private ObservableCollection<IMetadataItem> _filteredMetadataItems;
        private IMetadataItem _selectedMetadataItem;

        private string _selectedTypItem;
        private string _suchbegriff;

        private List<string> _typItems;

        public SearchViewModel()
        {
            TypItems = ComboBoxItems.Typ;

            CmdSuchen = new DelegateCommand(OnCmdSuchen);
            CmdReset = new DelegateCommand(OnCmdReset);
            CmdOeffnen = new DelegateCommand(OnCmdOeffnen, OnCanCmdOeffnen);
            _loadFileRepository = new LoadFileRepository();
            _filteredMetadataItems = new ObservableCollection<IMetadataItem>();
            //ShowData();
        }

        public DelegateCommand CmdOeffnen { get; }

        public DelegateCommand CmdSuchen { get; }

        public DelegateCommand CmdReset { get; }

        public string Suchbegriff
        {
            get => _suchbegriff;

            set => SetProperty(ref _suchbegriff, value);
        }

        public List<string> TypItems
        {
            get => _typItems;

            set => SetProperty(ref _typItems, value);
        }

        public string SelectedTypItem
        {
            get => _selectedTypItem;

            set => SetProperty(ref _selectedTypItem, value);
        }

        public ObservableCollection<IMetadataItem> FilteredMetadataItems
        {
            get => _filteredMetadataItems;

            set => SetProperty(ref _filteredMetadataItems, value);
        }

        /* private void ShowData()
         {
             _fileRepository = new FileRepository();
             var metadataList = _fileRepository.LoadMetadata();
             foreach (var m in metadataList)
             {
                 FilteredMetadataItems.Add(m);
             }
         }*/

        public IMetadataItem SelectedMetadataItem
        {
            get => _selectedMetadataItem;

            set
            {
                if (SetProperty(ref _selectedMetadataItem, value)) CmdOeffnen.RaiseCanExecuteChanged();
            }
        }

        private bool OnCanCmdOeffnen()
        {
            return SelectedMetadataItem != null;
        }

        private void OnCmdOeffnen()
        {
            var process = new Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = SelectedMetadataItem.PathInRepo;
            process.Start();
        }

        private void OnCmdSuchen()
        {
            // TODO: Add your Code here
            //  _loadFileRepository.LoadMetadaten(List<KeyValuePair<string _suchbegriff,List<IMetadataItem _filteredMetadataItems>>>_typItems);
        }

        private void OnCmdReset()
        {
            FilteredMetadataItems.Clear();
            Suchbegriff = null;
            SelectedTypItem = null;
        }
    }
}