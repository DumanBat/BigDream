using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BigDream.App
{
    public class LocalizationController : MonoBehaviour
    {
        private const string English = "English";
        private const string SELECTED_LANGUAGE_KEY = "SelectedLanguage";

        [SerializeField]
        private string[] _languages;

        [SerializeField]
        private TMP_Dropdown _selectLanguageDropdown;

        private void Awake()
        {
            LocalizationManager.Read();

            if (PlayerPrefs.HasKey(SELECTED_LANGUAGE_KEY))
                LocalizationManager.Language = PlayerPrefs.GetString(SELECTED_LANGUAGE_KEY);
            else
                LocalizationManager.Language = English;

            PopulateDropDown();
            SetDropdown();
        }

        private void PopulateDropDown()
        {
            _selectLanguageDropdown.ClearOptions();

            foreach (var language in _languages)
            {
                var optionData = new TMP_Dropdown.OptionData
                {
                    text = language
                };
                _selectLanguageDropdown.options.Add(optionData);
            }
        }

        private void SetDropdown()
        {
            _selectLanguageDropdown.value = System.Array.IndexOf(_languages, LocalizationManager.Language);

            _selectLanguageDropdown.onValueChanged.AddListener(delegate
            {
                OnLanguageChanged(_selectLanguageDropdown);
            });
        }

        private void OnLanguageChanged(TMP_Dropdown change)
        {
            LocalizationManager.Language = _languages[change.value];

            PlayerPrefs.SetString(SELECTED_LANGUAGE_KEY, LocalizationManager.Language);
        }
    }
}
