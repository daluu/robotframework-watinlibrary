/* Copyright (c) 2011 David Luu
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License. 
 */
using System;
using System.Collections.Generic;
using System.Net;
//get the following from www.watin.org
using WatiN.Core;
using WatiN.Core.DialogHandlers;
using WatiN.Core.Exceptions;
using WatiN.Core.Interfaces;
using WatiN.Core.Logging;

namespace RobotFramework
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class WatinLibrary
	{
		private string browser;
		WatiN.Core.IE ie;
		WatiN.Core.FireFox ff;
		
		//no exact matching APIs to RobotFramework Selenium API's?
		//Get Window Names
		//Get Window Titles
		//Get Window Identifiers
		//Select Window
		//Delete Cookie
		
		//***developer reference for WatiN, start***
		//imgs
		//Find.ByAlt(locator);
		//Find.BySrc(locator);
		
		//general
		//Find.ById(locator);
		//Find.ByClass(locator);
		//Find.ByDefault(locator);
		//Find.ByIndex(Int32.Parse(locator));
		
		//labels
		//Find.ByFor(locator);
		//Find.ByLabelText(locator);
		
		//form fields
		//Find.ByName(locator);
		//Find.ByValue(locator);
		//Find.ByText(locator);
		//***developer reference for WatiN, end***
		
		/// <summary>
		/// Default WatiN test library constructor, using Internet Explorer.
		/// </summary>
		public WatinLibrary()
		{
			browser = "ie";
			ie = new WatiN.Core.IE();
			ff = new WatiN.Core.FireFox();
		}
		
		/// <summary>
		/// WatiN test library constructor for selecting browser.
		/// 
		/// Supports Internet Explorer, with partial support for Firefox.
		/// </summary>
		/// <param name="pBrowser">Browser to use with WatiN. Use 'ie' for Internet Explorer or 'ff' for Firefox.</param>
		public WatinLibrary(string pBrowser)
		{
			browser = pBrowser;
			ie = new WatiN.Core.IE();
			ff = new WatiN.Core.FireFox();
		}
		
		/// <summary>
		/// Navigates the active browser instance to the provided URL.
		/// </summary>
		/// <param name="url">URL to navigate to.</param>
		public void go_to(string url)
		{
			Console.WriteLine("Opening url '{0}'",url);
			if(browser == "ie") ie.GoTo(url);
			else ff.GoTo(url);
		}
		
		/// <summary>
		/// Waits for a page load to happen.
		/// 
		/// This keyword can be used after performing an action that causes a page
		/// load to ensure that following keywords see the page fully loaded.
		/// 
		/// `timeout` is the time to wait for the page load to happen,
		/// after which this keyword fails. NOTE: but currently, probably doesn't.
		/// Need to figure out how to make it fail if/on timeout.
		/// </summary>
		/// <param name="timeout">Time to wait for the page load to happen.</param>
		public void wait_until_page_loaded(int timeout)
		{
			if(browser == "ie") ie.WaitForComplete(timeout);
			else ff.WaitForComplete(timeout);
		}
		
		/// <summary>
		/// Simulates the user clicking the "back" button on their browser.
		/// </summary>
		/// <returns>True if clicking "back" button succeeded, otherwise false.</returns>
		public bool go_back()
		{
			if(browser == "ie") return ie.Back();
			else return ff.Back();
		}
		
		/// <summary>
		/// Maximizes current browser window.
		/// </summary>
		public void maximize_browser_window()
		{
			if(browser == "ie") ie.ShowWindow(WatiN.Core.Native.Windows.NativeMethods.WindowShowStyle.ShowMaximized);
			else ff.ShowWindow(WatiN.Core.Native.Windows.NativeMethods.WindowShowStyle.ShowMaximized);
		}		
		
		/// <summary>
		/// Closes currently opened pop-up window.
		/// </summary>
		public void close_window()
		{
			if(browser == "ie") ie.Close();
			else ff.Close();
		}
		
		/// <summary>
		/// Returns the current location.
		/// </summary>
		/// <returns>URL of current location.</returns>
		public string get_location()
		{
			if(browser == "ie") return ie.Url;
			else return ff.Url;
		}
		
		/// <summary>
		/// Returns all cookies of the current page. 
		/// Supported on Internet Explorer only.
		/// </summary>
		/// <returns>Cookies from the current page.</returns>
		public string get_cookies()
		{
			if(browser == "ie") return ie.GetCookiesForUrl(ie.Uri).ToString();
			else return ""; //no cookie support for Firefox
		}
		
		/// <summary>
		/// Returns value of cookie found with `name`.
		/// If no cookie is found with `name`, this keyword fails.
		/// Supported on Internet Explorer only.
		/// </summary>
		/// <param name="name">Name of cookie to get</param>
		/// <returns>value of cookie found with `name`.</returns>
		public string get_cookie_value(string name)
		{
			if(browser == "ie") return ie.GetCookie(ie.Url,name);
			else return ""; //no cookie support for Firefox			
		}
		
		/// <summary>
		/// Deletes all cookies by calling `Delete Cookie` repeatedly.
		/// </summary>
		public void delete_all_cookies()
		{
			ie.ClearCookies();
		}
		
		/// <summary>
		/// Selects checkbox identified by `locator`.
		/// 
		/// Does nothing if checkbox is already selected. Key attributes for
		/// checkboxes are `id` and `name`. See `introduction` for details about
		/// locating elements.
		/// </summary>
		/// <param name="locator">Locating identifier for checkbox.</param>
		public void select_checkbox(string locator)
		{
			Console.WriteLine("Selecting checkbox '{0}'.",locator);
			if(browser == "ie")
			{
				try
				{
					ie.CheckBox(Find.ById(locator) || Find.ByClass(locator) || Find.ByDefault(locator) || Find.ByName(locator) || Find.ByValue(locator) || Find.ByText(locator) || Find.ByIndex(Int32.Parse(locator))).Checked = true;
				}
				catch
				{
					ie.CheckBox(Find.ById(locator) || Find.ByClass(locator) || Find.ByDefault(locator) || Find.ByName(locator) || Find.ByValue(locator) || Find.ByText(locator)).Checked = true;
				}
			}				
			else
			{
				try
				{
					ff.CheckBox(Find.ById(locator) || Find.ByClass(locator) || Find.ByDefault(locator) || Find.ByName(locator) || Find.ByValue(locator) || Find.ByText(locator) || Find.ByIndex(Int32.Parse(locator))).Checked = true;
				}
				catch
				{
					ff.CheckBox(Find.ById(locator) || Find.ByClass(locator) || Find.ByDefault(locator) || Find.ByName(locator) || Find.ByValue(locator) || Find.ByText(locator)).Checked = true;
				}
			}				
		}
		
		//more WatiN library keywords to be added below when have time...
	}
}