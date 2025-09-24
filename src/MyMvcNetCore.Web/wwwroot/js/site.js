
    document.addEventListener('DOMContentLoaded', function() {
            const closeBtn = document.getElementById('close-sidebar');
    const sidebar = document.getElementById('sidebarCollapse');

    if (closeBtn && sidebar) {
        closeBtn.addEventListener('click', function () {
            sidebar.classList.remove('show');
        });
            }
        });
