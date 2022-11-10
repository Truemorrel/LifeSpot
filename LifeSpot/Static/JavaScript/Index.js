let currentDate = document.querySelector('.curDate');

let session = new Map();

currentDate.textContent += new Date().toLocaleDateString();

setTimeout(() => alert('Подпишитесь на наш сайт!'), 60000);

let sessionLog = function logSession(session) {
    for (let result of session) {
        console.log(result);
    }
}

var handleSession = function () {
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

let contentFilter = function filterContent(inputParseFunction) {

    let elements = document.getElementsByClassName('video-container');

    for (let i = 0; i <= elements.length; i++) {
        let videoText = elements[i].querySelector('.video-title').innerText;
        if (!videoText.toLowerCase().includes(inputParseFunction())) {
            elements[i].style.display = 'none';
        } else {
            elements[i].style.display = 'inline-block';
        }
    }
};

/*
* Запишем отзыв на страницу
*
* */
const writeReview = review => {
    document.getElementsByClassName('reviews')[0].innerHTML += '    <div class="review-text">\n' +
        `<p> <i> <b>${review['userName']}</b>  ${review['date']}</i></p>` +
        `<p>${review['comment']}</p>` +
        '</div>';
}
/*
* Запросим пользовательский ввод
* и сохраним отзыв в объект
*
* */
function getReview() {
    // Создадим объект
    let review = {}

    // Сохраним свойство имени
    review["userName"] = prompt("Как вас зовут ?")
    if (review["userName"] == null) {
        return
    }

    // Сохраним текст отзыва
    review["comment"] = prompt("Напишите свой отзыв")
    if (review["comment"] == null) {
        return
    }

    // Сохраним текущее время
    review["date"] = new Date().toLocaleString()

    // Добавим на страницу
    writeReview(review)
}

