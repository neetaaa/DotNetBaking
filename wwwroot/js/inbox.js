document.addEventListener("DOMContentLoaded", async () => {

    const toUserSelect = document.getElementById("toUserId");
    const currentUserId = localStorage.getItem("userId");

    // LOAD USERS FROM DB
    const res = await fetch("/api/user/all");
    const users = await res.json();

    users.forEach(u => {
        if (u.id != currentUserId) {
            const opt = document.createElement("option");
            opt.value = u.id;
            opt.textContent = u.username;
            toUserSelect.appendChild(opt);
        }
    });

    // SEND SLICE
    document.getElementById("sendBtn").addEventListener("click", async () => {

        const toUserId = toUserSelect.value;
        const message = document.getElementById("messageText").value;

        if (!toUserId || !message) {
            alert("Fill all fields 🍰");
            return;
        }

        const response = await fetch("/api/slice/send", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                fromUserId: Number(currentUserId),
                toUserId: Number(toUserId),
                message: message
            })
        });

        if (response.ok) {
            alert("Slice sent 🍰");
            document.getElementById("messageText").value = "";
        } else {
            alert("Failed to send slice ❌");
        }
    });
});
