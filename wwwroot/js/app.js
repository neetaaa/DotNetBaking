let token = '';
let userId = 0;
let userLevel = 1;

async function register() {
    const username = document.getElementById('regUsername').value;
    const email = document.getElementById('regEmail').value;
    const password = document.getElementById('regPassword').value;

    const res = await fetch('/api/Auth/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, email, passwordHash: password, Level: 1 })
    });

    const data = await res.text();
    alert(data);
}

async function login() {
    const username = document.getElementById('loginUsername').value;
    const password = document.getElementById('loginPassword').value;

    const res = await fetch('/api/Auth/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username: username, passwordHash: password })
    });

    const data = await res.json();
    if (data.UserId) { 
        token = data.Token;
        userId = data.UserId;
        userLevel = data.Level;
        document.getElementById('auth').style.display = 'none';
        document.getElementById('menu').style.display = 'block';
        loadRecipes();
    } else {
        alert(data.message || 'Login failed');
    }
}


async function loadRecipes() {
    const res = await fetch(`/api/Recipes?userLevel=${userLevel}`, {
        headers: { 'Authorization': `Bearer ${token}` }
    });
    const recipes = await res.json();
    const list = document.getElementById('recipesList');
    list.innerHTML = '';
    recipes.forEach(r => {
        const li = document.createElement('li');
        li.textContent = `${r.name} (Level ${r.requiredLevel})`;
        list.appendChild(li);
    });
}
