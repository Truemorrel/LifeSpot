function dateInline() {
    document.querySelector('.curDate').textContent += new Date().toLocaleDateString();
}

setTimeout(() => alert('Подпишитесь на наш сайт!'), 60000);

let session = new Map();
function sessionLog(session) {
    for (let result of session) {
        console.log(result);
    }
}

function handleSession() {
    session.set("userAgent", window.navigator.userAgent);
    session.set("age", prompt("Пожалуйста, введите ваш возраст?"));
}

function checkAge() {
    // Проверка на возраст и сохранение сессии
    if (session.get("age") >= 18) {
        let startDate = new Date().toLocaleString();

        alert("Приветствуем на LifeSpot! " + '\n' + "Текущее время: " + startDate);
        session.set("startDate", startDate);
    }
    else {
        alert("Наши трансляции не предназначены для лиц моложе 18 лет. Вы будете перенаправлены");
        window.location.href = "http://www.google.com";
    }
}

function contentFilter(inputParseFunction) {
    let elements = document.getElementsByClassName('video-container')
    for (let i = 0; i <= elements.length; i++) {
        let videoText = elements[i].querySelector('.video-title').innerText;
        if (!videoText.toLowerCase().includes(inputParseFunction())) {
            elements[i].style.display = 'none';
        } else {
            elements[i].style.display = 'inline-block';
        }
    }
}


