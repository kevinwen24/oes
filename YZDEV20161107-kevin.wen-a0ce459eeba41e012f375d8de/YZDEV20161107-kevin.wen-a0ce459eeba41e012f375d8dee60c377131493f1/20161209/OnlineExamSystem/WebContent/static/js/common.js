function getObjById(key) {
    return document.getElementById(key);
}

function getObjIndexFirstByName(key) {
    return document.getElementsByName(key)[0];
}

function inputValueTrim(ele) {
    return ele.value.trim()
}

function setEleStyleDiaplay(ele,attr) {
    ele.style.display=attr;
}

function setEleStylevisibility(ele,attr) {
    ele.style.visibility = attr;
}

function setEleBorder(ele,attr) {
    ele.style.border=attr;
}
