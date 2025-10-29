// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Theme toggling functionality
document.addEventListener('DOMContentLoaded', function() {
    try {
        const themeToggle = document.getElementById('theme-toggle');
        if (!themeToggle) {
            console.warn('Theme toggle button not found');
            return;
        }
        
        const themeIcon = themeToggle.querySelector('i');
        if (!themeIcon) {
            console.warn('Theme icon not found within toggle button');
            return;
        }
        
        // Function to apply theme
        function applyTheme(theme) {
            try {
                if (theme === 'dark') {
                    document.documentElement.setAttribute('data-theme', 'dark');
                    themeIcon.classList.remove('fa-sun');
                    themeIcon.classList.add('fa-moon');
                } else {
                    document.documentElement.removeAttribute('data-theme');
                    themeIcon.classList.remove('fa-moon');
                    themeIcon.classList.add('fa-sun');
                }
            } catch (error) {
                console.error('Error applying theme:', error);
            }
        }
        
        // Function to detect system preference
        function getSystemPreference() {
            if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
                return 'dark';
            }
            return 'light';
        }
        
        // Function to get user preference with fallback to system preference
        function getUserPreference() {
            const savedTheme = localStorage.getItem('theme');
            if (savedTheme === 'dark' || savedTheme === 'light') {
                return savedTheme;
            }
            return getSystemPreference();
        }
        
        // Apply initial theme
        const initialTheme = getUserPreference();
        applyTheme(initialTheme);
        
        // Listen for system preference changes
        if (window.matchMedia) {
            const colorSchemeMediaQuery = window.matchMedia('(prefers-color-scheme: dark)');
            colorSchemeMediaQuery.addEventListener('change', (e) => {
                // Only change theme if user hasn't set a preference
                if (!localStorage.getItem('theme')) {
                    applyTheme(e.matches ? 'dark' : 'light');
                }
            });
        }
        
        // Theme toggle click handler
        themeToggle.addEventListener('click', function() {
            try {
                // Check current theme
                const currentTheme = document.documentElement.getAttribute('data-theme');
                const newTheme = currentTheme === 'dark' ? 'light' : 'dark';
                
                // Apply theme
                applyTheme(newTheme);
                
                // Save preference
                localStorage.setItem('theme', newTheme);
            } catch (error) {
                console.error('Error toggling theme:', error);
            }
        });
    } catch (error) {
        console.error('Error initializing theme functionality:', error);
    }
});

document.addEventListener('DOMContentLoaded', function () {
    const downloadLink = document.getElementById('resume-download-link');
    const countSpan = document.getElementById('resume-download-count');
    
    if (downloadLink && countSpan) {
        let downloadCount = parseInt(localStorage.getItem('resumeDownloadCount')) || 0;
        
        function updateCountDisplay() {
            if (downloadCount > 0) {
                countSpan.innerText = downloadCount;
                countSpan.style.display = 'inline';
            } else {
                countSpan.style.display = 'none';
            }
        }

        updateCountDisplay();

        downloadLink.addEventListener('click', function () {
            downloadCount++;
            localStorage.setItem('resumeDownloadCount', downloadCount);
            updateCountDisplay();
        });
    }
});
