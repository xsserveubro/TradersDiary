if (window.jQuery) {
    alert("JQuery работает");
} else {
    let elements = document.getElementById("EditorArea").children;

    elements.forEach((item) => {
        console.log(item.innerHtml)
    });

    
}

window.onload = function () {
    inactivityTime();
};

let editor = document.getElementById("EditorArea");

var inactivityTime = function () {
    var time;
    window.onload = resetTimer;

    editor.onmouseover = resetTimer;
    editor.onkeydown = resetTimer;

    editor.style.contenteditable
    function parseElements() {
        alert("В этот момент State обновляется.")
        this.state
    };

    function resetTimer() {
        clearTimeout(time);
        time = setTimeout(parseElements, 3000)
    };
};


var items = [].slice.call(document.getElementById('EditorArea').children);
items.forEach((item) => {
    console.log(item.textContent);
});

let items = [].slice.call(document.getElementById('EditorArea').children);
items.forEach((item) => {
    console.log(item.textContent);
});












