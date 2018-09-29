using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Repositories;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    internal class DocumentDetailViewModel : BindableBase
    {
        private readonly Action _navigateBack;

        private string _benutzer;

        private string _bezeichnung;

        private DateTime _erfassungsdatum;

        private string _filePath;

        private bool _isRemoveFileEnabled;

        private IMetadataItem _metadataItem;
        private readonly CreateFilePfad _createFilePfad;
        private string _selectedTypItem;

        private string _stichwoerter;

        private List<string> _typItems;

        private DateTime? _valutaDatum;

        public DocumentDetailViewModel(string benutzer, Action navigateBack)
        {
            _navigateBack = navigateBack;
            Benutzer = benutzer;
            Erfassungsdatum = DateTime.Now;
            TypItems = ComboBoxItems.Typ;

            CmdDurchsuchen = new DelegateCommand(OnCmdDurchsuchen);
            CmdSpeichern = new DelegateCommand(OnCmdSpeichern);
        }

        public string Stichwoerter
        {
            get => _stichwoerter;

            set => SetProperty(ref _stichwoerter, value);
        }

        public string Bezeichnung
        {
            get => _bezeichnung;

            set => SetProperty(ref _bezeichnung, value);
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

        public DateTime Erfassungsdatum
        {
            get => _erfassungsdatum;

            set => SetProperty(ref _erfassungsdatum, value);
        }

        public string FilePfadname
        {
            get =>_filePath;
            set => SetProperty(ref _filePath, value);
        }

        public string Benutzer
        {
            get => _benutzer;

            set => SetProperty(ref _benutzer, value);
        }

        public DelegateCommand CmdDurchsuchen { get; }

        public DelegateCommand CmdSpeichern { get; }

        public DateTime? ValutaDatum
        {
            get => _valutaDatum;

            set => SetProperty(ref _valutaDatum, value);
        }

        public bool IsRemoveFileEnabled
        {
            get => _isRemoveFileEnabled;

            set => SetProperty(ref _isRemoveFileEnabled, value);
        }

        private void OnCmdDurchsuchen()
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            
            if (result.GetValueOrDefault()) _filePath = openFileDialog.FileName;
        }

        private void OnCmdSpeichern()
        {
            if (CheckReqiredFields() && _filePath != null)
            {
                _metadataItem = new MetadataItem(this);
              //_createFilePfad.Add
                _navigateBack();
            }
            else
            {
                if (!CheckRequiredFieldsBezeichnung())
                {
                    MessageBox.Show("Sie habe noch keine Bezeichnung eingegeben");
                }

                if (!CheckRequiredFieldsValutaDatum())
                {
                    MessageBox.Show("Sie haben noch kein Valuta Datum eingegeben");
                }

                if (!CheckRequiredFieldsSelectTypeItem())
                {
                    MessageBox.Show("Sie haben ein das Dokument noch nicht zu einem Typ hinzugefügt");
                }

            }
        }

        private bool CheckReqiredFields()
        {
            return CheckRequiredFieldsBezeichnung() && CheckRequiredFieldsValutaDatum() &&
                   CheckRequiredFieldsSelectTypeItem();
        }

        private bool CheckRequiredFieldsBezeichnung()
        {
            var bezeichnng = !string.IsNullOrEmpty(Bezeichnung);
            return bezeichnng;
        }

        private bool CheckRequiredFieldsValutaDatum()
        {
            var valutaDatum = !string.IsNullOrEmpty(ValutaDatum.ToString());
            return valutaDatum;
        }

        private bool CheckRequiredFieldsSelectTypeItem()
        {
            var selectedTypeItem = !string.IsNullOrEmpty(SelectedTypItem);
            return selectedTypeItem;
        }

    }

    internal class FileSystemService
    {
    }
}