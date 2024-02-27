function onEdit(td) {
    document.getElementById("Dateupload").disabled = false;
    selectedRow = td.parentElement.parentElement;
    document.getElementById("Trackname").value = selectedRow.cells[1].innerHTML;
    document.getElementById("Describe").value = selectedRow.cells[2].innerHTML;
    //document.getElementById("Source").value = selectedRow.cells[3].innerHTML;
    document.getElementById("Duration").value = selectedRow.cells[5].innerHTML;
    if (selectedRow.cells[7].innerHTML != "") {
        var Datecreate = selectedRow.cells[7].innerHTML;
        document.getElementById("Dateupload").value = Datecreate;
    }
    document.getElementById("Dateupload").value = selectedRow.cells[7].innerHTML;

    document.querySelector(".Idlesson").value = selectedRow.cells[8].innerHTML;
    document.getElementById("Idtrack").value = selectedRow.cells[9].innerHTML;

    document.querySelector(".vscomp-value").innerText = selectedRow.cells[0].innerHTML;
    //audioSource.src = selectedRow.cells[3].querySelector("audio#SourceEdit").src;
    //audio.load();
    //setTimeout(() => {
    //    document.getElementById("Duration").value = Math.round(document.getElementById('audio').duration);

    //}, 100);

    btnAdd.style.display = "none";
    btnUpdate.style.display = "block";
    btnCancel.style.display = "block";

}
btnUpdate.addEventListener("click", function () {
    btnAdd.style.display = "block";
    btnUpdate.style.display = "none";
    btnCancel.style.display = "none";

})