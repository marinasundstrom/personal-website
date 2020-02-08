interface Window {
    setDocumentTitle(value: string): void;
    topFunction(): void;
    initHighlight(): void;
    openInNewTab(href: string): void;
}

let hljs: any;

window.setDocumentTitle = (value) => {
    document.title = value;
}

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("scrollTopButton")!.style.display = "block";
    } else {
        document.getElementById("scrollTopButton")!.style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
window.topFunction = function () {
    window.scrollTo({
        top: 0,
        left: 0,
        behavior: 'smooth'
    });
}

window.initHighlight = () => {
    for (const element of Array.from(document.getElementsByTagName("code"))) {
        hljs.highlightBlock(element);
        hljs.lineNumbersBlock(element);
    }
};

window.openInNewTab = (href) => {
    Object.assign(document.createElement('a'), {
        target: '_blank',
        href,
    }).click();
};