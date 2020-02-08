interface Window {
    disqus: {
        initThread(config: DisqusConfig): void;
        initCount(config: DisqusConfig): void;
    }
}

interface DisqusConfig
{
    site: string;
    page: {
        url: string;
        identifier: string;
    }
}

declare var DISQUSWIDGETS: any | undefined;

window.disqus = {
    initThread(config: DisqusConfig) {
        var d = document;

        var dsqThread = document.getElementById("dsq-thread");
        if (dsqThread) {
            (d.head || d.body).removeChild(dsqThread);
        }
        
        var d = document, s = d.createElement('script');
        s.id = "dsq-thread";
        s.src = `https://${config.site}.disqus.com/embed.js`;
        s.setAttribute('data-timestamp', new Date() as any);
        (d.head || d.body).appendChild(s);
    },

    initCount(config: DisqusConfig) {    
        var d = document;

        var countScrTag = document.getElementById("dsq-count-scr");
        if (countScrTag) {
            d.body.removeChild(countScrTag);
        }

        var d = document, s = d.createElement('script');
        s.id = "dsq-count-scr";
        s.src = `https://${config.site}.disqus.com/count.js`;
        //s.async = false;
        d.body.appendChild(s);

        if (typeof DISQUSWIDGETS != "undefined") {
            DISQUSWIDGETS.getCount({ reset: true });
        }
    }
};