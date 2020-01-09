﻿using DemoAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.Network;
using OpenQA.Selenium.Support.UI;

namespace DemoAutomation.PageObjects.Cars
{
    public class MainCarSettingsSection : Page
    {
        private IWebElement CarStatusSelect => driver.FindElement(By.Name("carstatus"));

        private IWebElement CarTypeDropDown => driver.FindElement(By.Id("s2id_autogen21"));

        private IWebElement IsFeaturedSelect => driver.FindElement(By.Id("isfeatured"));

        private IWebElement FeaturedFromDateField => driver.FindElement(By.Name("ffrom"));

        private IWebElement FeaturedToDateField => driver.FindElement(By.Name("fto"));

        private IWebElement DepositSelect => driver.FindElement(By.Name("deposittype"));

        private IWebElement DepositAmountField => driver.FindElement(By.Name("depositvalue"));

        private IWebElement VatTaxSelect => driver.FindElement(By.Name("taxtype"));

        private IWebElement VatAmountField => driver.FindElement(By.Name("taxvalue"));

        public CarCreationPage SelectCarStatus(CarModel car)
        {
            var statusSelect = new SelectElement(CarStatusSelect);
            statusSelect.SelectByText(car.Setting.CarStatus.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SelectCarType(CarModel car)
        {
            CarTypeDropDown.Click();
            WaitForElementToBeVisible(By.ClassName("select2-drop-active"));
            var input = driver.FindElement(By.XPath("//div[contains(@class, 'select2-drop-active')]//input"));
            input.SendKeys(car.Setting.CarType.ToString());
            input.SendKeys(Keys.Enter);
            return new CarCreationPage();
        }

        public CarCreationPage SelectIsFeatured(CarModel car)
        {
            var isFeaturedSelect = new SelectElement(IsFeaturedSelect);
            isFeaturedSelect.SelectByText(car.Setting.IsFeatured.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SetFeaturedFrom(CarModel car)
        {
            FeaturedFromDateField.SendKeys(car.Setting.FeaturedFrom.ToShortDateString());
            return new CarCreationPage();
        }

        public CarCreationPage SetFeaturedTo(CarModel car)
        {
            FeaturedToDateField.SendKeys(car.Setting.FeaturedTo.ToShortDateString());
            //Click to hide the date pickers
            FeaturedToDateField.Click();
            return new CarCreationPage();
        }

        public CarCreationPage SelectDepositType(CarModel car)
        {
            var depositSelect = new SelectElement(DepositSelect);
            depositSelect.SelectByText(car.Setting.DepositType.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SetDepositAmount(CarModel car)
        {
            DepositAmountField.SendKeys(car.Setting.DepositAmount.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SelectVatType(CarModel car)
        {
            var vatSelect = new SelectElement(VatTaxSelect);
            vatSelect.SelectByText(car.Setting.VatType.ToString());
            return new CarCreationPage();
        }

        public CarCreationPage SetVatAmount(CarModel car)
        {
            VatAmountField.SendKeys(car.Setting.VatAmount.ToString());
            return new CarCreationPage();
        }
    }
}