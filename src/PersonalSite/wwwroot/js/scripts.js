"use strict";
window.blazorHelpers = {
    scrollToFragment: function (elementId) {
        var element = document.getElementById(elementId);
        if (element) {
            element.scrollIntoView({
                behavior: 'smooth'
            });
        }
    }
};
window.disqus = {
    initThread: function (config) {
        var d = document;
        var dsqThread = document.getElementById("dsq-thread");
        if (dsqThread) {
            DISQUS.reset();
            return;
        }
        var d = document, s = d.createElement('script');
        s.id = "dsq-thread";
        s.src = "https://" + config.site + ".disqus.com/embed.js";
        s.setAttribute('data-timestamp', new Date());
        (d.head || d.body).appendChild(s);
    },
    initCount: function (config) {
        var d = document;
        var countScrTag = document.getElementById("dsq-count-scr");
        if (countScrTag) {
            d.body.removeChild(countScrTag);
        }
        var d = document, s = d.createElement('script');
        s.id = "dsq-count-scr";
        s.src = "https://" + config.site + ".disqus.com/count.js";
        //s.async = false;
        d.body.appendChild(s);
        if (typeof DISQUSWIDGETS != "undefined") {
            DISQUSWIDGETS.getCount({ reset: true });
        }
    }
};
var hljs;
window.setDocumentTitle = function (value) {
    document.title = value;
};
// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction(); };
function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("scrollTopButton").style.display = "block";
    }
    else {
        document.getElementById("scrollTopButton").style.display = "none";
    }
}
// When the user clicks on the button, scroll to the top of the document
window.topFunction = function () {
    window.scrollTo({
        top: 0,
        left: 0,
        behavior: 'smooth'
    });
};
window.initHighlight = function () {
    for (var _i = 0, _a = Array.from(document.getElementsByTagName("code")); _i < _a.length; _i++) {
        var element = _a[_i];
        hljs.highlightBlock(element);
        hljs.lineNumbersBlock(element);
    }
};
window.openInNewTab = function (href) {
    Object.assign(document.createElement('a'), {
        target: '_blank',
        href: href,
    }).click();
};
