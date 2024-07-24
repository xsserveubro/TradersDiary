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

document.getElementById(window.getSelection().baseNode.parentNode.id).style.fontSize = "32px";







function createHeader1() {
    // Нажатие на клавишу
    // Отследить расположение каретки
    // Создать DIV с контентом HEADER 1
    // Дать ему class - Header1


    // let selection = window.getSelection();
    // let range = selection.getRangeAt(0);
    // let cloneRange = range.cloneRange();
    // cloneRange.selectNodeContents();
    // cloneRange.setEnd(range.endContainer, range.endOffset);

    // let cursorPosition = cloneRange.toString().length;

    let caretPos = 0;
    if (window.getSelection) {
        let sel = window.getSelection();
        let range = sel.getRangeAt(0);
        caretPos = range.endOffset;
    }

    console.log(caretPos);
}





var inactivityTime = function () {
    var time;
    window.onload = resetTimer;

    let editor = document.getElementById("EditorArea");

    editor.onmouseover = resetTimer;
    editor.onkeydown = resetTimer;

    function parseElements() {
        setIdNewElements();
        //let items = [].slice.call(document.getElementById('EditorArea').children);

        //let json = JSON.stringify(items);
        //console.log(json);


        //console.log("Преобразование всех объектов.");
        //let itemsJson = [];
        // items.forEach((item) => function() {
        //     let itemJson = {
        //         Id: item.id,
        //         ContentType: item.ContentType,
        //         Content: item.Content,
        //     }

        // });
        //console.log("Преобразование всех объектов.");


        // let itemJson = {
        //     Id: items[1].id,
        //     ContentType: "text",
        //     Content: items[1].innerText,
        // }
        //console.log(items[1].innerText)

        // $.ajax({
        //     url: "/Plan/SaveData",
        //     type: "POST",
        //     data: itemJson,
        //     success: function (response) {
        //         console.log(response);
        //     },
        //     error: function(request, status, error){
        //         console.log(request.responseText);
        //     }
        // })

    };

    function resetTimer() {
        clearTimeout(time);
        time = setTimeout(parseElements, 1000)
    };
};