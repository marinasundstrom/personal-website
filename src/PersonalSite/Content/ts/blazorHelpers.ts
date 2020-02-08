interface Window {
    blazorHelpers: {
        scrollToFragment(elementId: string): void
    }
}

window.blazorHelpers = {
    scrollToFragment: (elementId) => {
        var element = document.getElementById(elementId);

        if (element) {
            element.scrollIntoView({
                behavior: 'smooth'
            });
        }
    }
};