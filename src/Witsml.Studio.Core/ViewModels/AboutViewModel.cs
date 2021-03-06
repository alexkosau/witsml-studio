﻿//----------------------------------------------------------------------- 
// PDS.Witsml.Studio, 2016.1
//
// Copyright 2016 Petrotechnical Data Systems
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using System.IO;
using System.Windows;
using Caliburn.Micro;
using PDS.Framework;
using PDS.Witsml.Studio.Core.Properties;
using PDS.Witsml.Studio.Core.Runtime;

namespace PDS.Witsml.Studio.Core.ViewModels
{
    /// <summary>
    /// Manages UI elements for the About dialog.
    /// </summary>
    /// <seealso cref="Caliburn.Micro.Screen" />
    public sealed class AboutViewModel : Screen
    {
        private static readonly string _applicationTitle = Settings.Default.ApplicationTitle;

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutViewModel" /> class.
        /// </summary>
        /// <param name="runtime">The runtime service.</param>
        public AboutViewModel(IRuntimeService runtime)
        {
            DisplayName = "About";
            Runtime = runtime;
            License = new TextEditorViewModel(Runtime, null, true);
            Notice = new TextEditorViewModel(Runtime, null, true);
            ApplicationTitle = _applicationTitle;
            ApplicationVersion = Application.Current.GetType().GetAssemblyVersion();
        }

        /// <summary>
        /// Gets the runtime service.
        /// </summary>
        /// <value>The runtime service.</value>
        public IRuntimeService Runtime { get; }

        /// <summary>
        /// Gets the license text editor control.
        /// </summary>
        /// <value>The license text editor control.</value>
        public TextEditorViewModel License { get; }

        /// <summary>
        /// Gets the notice text editor control.
        /// </summary>
        /// <value>The notice text editor control.</value>
        public TextEditorViewModel Notice { get; }

        /// <summary>
        /// Gets the application title.
        /// </summary>
        /// <value>The application versiontitle.</value>
        public string ApplicationTitle { get; }

        /// <summary>
        /// Gets the application version.
        /// </summary>
        /// <value>The application version.</value>
        public string ApplicationVersion { get; }

        /// <summary>
        /// Called when initializing.
        /// </summary>
        protected override void OnInitialize()
        {
            License.SetText(File.ReadAllText("LICENSE.txt"));
            Notice.SetText(File.ReadAllText("NOTICE.txt"));
        }
    }
}
