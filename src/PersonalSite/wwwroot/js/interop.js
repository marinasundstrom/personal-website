var hljs;
window.setDocumentTitle = function (value) {
    document.title = value;
};
window.onscroll = function () { scrollFunction(); };
function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("scrollTopButton").style.display = "block";
    }
    else {
        document.getElementById("scrollTopButton").style.display = "none";
    }
}
window.topFunction = function () {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
};
window.initHighlight = function () {
    for (var _i = 0, _a = Array.from(document.getElementsByTagName("code")); _i < _a.length; _i++) {
        var element = _a[_i];
        hljs.highlightBlock(element);
        hljs.lineNumbersBlock(element);
    }
};
//# sourceMappingURL=interop.js.map