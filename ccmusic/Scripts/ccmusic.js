$("#txtFilter").on("keyup", function () {
    alert("click");
    var search = this.value; if (search == '') { return }
    $(".searchable").each(function () {
        a = this; if (a.innerText.search(search) > 0) { this.hidden = false } else { this.hidden = true }
    });
})
