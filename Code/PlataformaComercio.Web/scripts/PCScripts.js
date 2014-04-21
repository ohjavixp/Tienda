var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-3688108-10']);
_gaq.push(['_trackPageview']);

(function () {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();


$(document).ready(function () {

    // Initialize Menu
    $('#jGlide_001').jGlideMenu({
        tileSource: '.jGlide_001_tiles',
        defaultScrollSpeed: 0
    }).show();

    try {
        ShowCategoryMenu();
    } catch (e) {
        jQuery.jGlideMenu.defaultScrollSpeed = 750;
    }


});

//jGrowl
$(function () {
    $('.ui-state-default').hover(
					function () { $(this).addClass('ui-state-hover'); },
					function () { $(this).removeClass('ui-state-hover'); }
				)
				.mousedown(function () { $(this).addClass('ui-state-active'); })
				.mouseup(function () { $(this).removeClass('ui-state-active'); })
				.mouseout(function () { $(this).removeClass('ui-state-active'); });
});