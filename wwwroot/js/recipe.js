document.addEventListener("DOMContentLoaded", () => {

    const ingredients = document.querySelectorAll(".ingredient");
    const mixBtn = document.querySelector(".mix-btn");
    const dough = document.querySelector(".dough");
    const ovenIcon = document.querySelector(".oven-icon");

    ovenIcon.addEventListener("click", () => {
        window.location.href = "/Menu/Oven";
    });


    let addedIngredients = 0;

    // INGREDIENT CLICK
    ingredients.forEach(item => {
        item.addEventListener("click", () => {

            addedIngredients++;

            // GROW DOUGH
            dough.style.width = `${140 + addedIngredients * 18}px`;
            dough.style.height = `${50 + addedIngredients * 10}px`;

            // disable ingredient
            item.style.opacity = "0.4";
            item.style.pointerEvents = "none";
        });
    });

    // MIX BUTTON
    mixBtn.addEventListener("click", () => {

        if (addedIngredients === 0) {
            alert("Add ingredients first 😄");
            return;
        }

        dough.classList.add("mixing");

        setTimeout(() => {
            dough.classList.remove("mixing");
        }, 900);
    });

});
