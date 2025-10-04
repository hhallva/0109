// =============== 5.5.1: Пошаговая отладка ===============
function debugFunction() {
  let x = 10;
  let y = 20;
  let sum = x + y;
  console.log("Сумма x + y:", sum);
}

document.getElementById("debugBtn").addEventListener("click", debugFunction);

// =============== 5.5.2: Счётчик нажатий ===============
let clickCount = 0;

document.getElementById("counterBtn").addEventListener("click", () => {
  clickCount++;
  console.log("Кнопка нажата", clickCount, "раз");
});

// =============== 5.5.2: Цикл от 1 до 100 ===============
document.getElementById("loopBtn").addEventListener("click", () => {
  console.log("=== Начало цикла 1–100 ===");
  for (let i = 1; i <= 100; i++) {
    console.log(i);
  }
  console.log("=== Конец цикла ===");
});

// =============== 5.5.3: Разные типы сообщений ===============
document.getElementById("logTypesBtn").addEventListener("click", () => {
  console.log("✅ Это информационное сообщение (console.log)");
  console.warn("⚠️ Это предупреждение (console.warn)");
  console.error("❌ Это ошибка (console.error)");
});