const buttons = document.querySelectorAll(".time-buttons button");
const timeSpan = document.getElementById("time");
const result = document.getElementById("result");
const doneBtn = document.querySelector(".done-btn");

buttons.forEach(btn => {
    btn.addEventListener("click", () => {
        let time = btn.dataset.time;
        let fastTime = 5; 

        timeSpan.innerText = time + " min";
        result.innerText = "Baking... 🔥";

        let countdown = fastTime;
        const interval = setInterval(() => {
            countdown--;
            if (countdown === 0) {
                clearInterval(interval);
                result.innerText = "🎉 Cake Ready! Level 1 Passed!";
                doneBtn.classList.remove("hidden");
            }
        }, 1000);
    });
});

function goMenu() {
    window.location.href = "/Menu";
}
