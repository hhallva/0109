const { Builder, By, until } = require('selenium-webdriver');
const chai = require('chai');
const assert = chai.assert;
const path = require('path');

// Опционально: если используете chromedriver из npm
// require('chromedriver');

describe('UI Tests', function () {
  this.timeout(30000); // Увеличиваем таймаут для асинхронных операций

  let driver;

  before(async function () {
    driver = await new Builder().forBrowser('chrome').build();
    const htmlPath = path.resolve(__dirname, '..', 'index.html');
    await driver.get(`file://${htmlPath}`);
  });

  after(async function () {
    await driver.quit();
  });

  it('H1 заголовок должен быть обновлён', async function () {
    const h1 = await driver.findElement(By.tagName('h1'));
    const text = await h1.getText();
    assert.equal(text, 'Тестирование с DevTools');
  });

  it('Кнопка .button-class должна существовать', async function () {
    const button = await driver.findElement(By.className('button-class'));
    const displayed = await button.isDisplayed();
    assert.isTrue(displayed);
  });

  it('Форма и поле #searchText должны существовать', async function () {
    const form = await driver.findElement(By.tagName('form'));
    const input = await driver.findElement(By.id('searchText'));
    assert.isTrue(await form.isDisplayed());
    assert.isTrue(await input.isDisplayed());
  });

  it('Кнопка .load-data и контейнер .data-container должны существовать', async function () {
    const loadBtn = await driver.findElement(By.className('load-data'));
    const container = await driver.findElement(By.className('data-container'));
    assert.isTrue(await loadBtn.isDisplayed());
    assert.isTrue(await container.isDisplayed());
  });

  it('Динамический элемент появляется через 10 секунд', async function () {
    const element = await driver.wait(
      until.elementLocated(By.className('dynamic-element')),
      12000
    );
    const text = await element.getText();
    assert.include(text, 'добавлен динамически через 10 секунды');
  });

  it('Сообщение обновляется через 20 секунд', async function () {
    await driver.wait(async () => {
      const msg = await driver.findElement(By.id('message')).getText();
      return msg === 'Сообщение обновлено динамически';
    }, 22000);
  });

  it('Ошибка отображается через 3 секунды', async function () {
    await driver.wait(async () => {
      const errorMsg = await driver.findElement(By.id('error-message')).getText();
      return errorMsg.includes('Ошибка через 3 секунды');
    }, 5000);
  });

  it('Глобальное состояние обновляется при клике', async function () {
    const button = await driver.findElement(By.className('button-class'));
    await button.click();

    // Ждём немного, чтобы состояние обновилось
    await driver.sleep(500);

    const state = await driver.executeScript('return window.testState;');
    assert.equal(state.clickCount, 1);
    assert.include(state.lastMessage, 'Кнопка нажата 1 раз');
  });

  it('Данные загружаются после клика по кнопке .load-data', async function () {
    const loadBtn = await driver.findElement(By.className('load-data'));
    await loadBtn.click();

    // Ждём появления хотя бы одного продукта
    await driver.wait(
      until.elementLocated(By.css('.data-container .product')),
      10000
    );

    const products = await driver.findElements(By.css('.data-container .product'));
    assert.isAbove(products.length, 0);

    const first = products[0];
    const imgSrc = await first.findElement(By.tagName('img')).getAttribute('src');
    const text = await first.getText();

    assert.isNotEmpty(imgSrc);
    assert.include(text, 'Цена:');
  });
});