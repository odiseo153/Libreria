import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appSidebarToggle]'
})
export class SidebarToggleDirective {
  private isMobile = false;
  private sidebarRef!: ElementRef;

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  @HostListener('click')
  onClick() {
    if (this.isMobile) {
      const sidebar = document.getElementById('default-sidebar');
      if (sidebar) {
        const isOpen = sidebar.classList.contains('-translate-x-0');
        this.renderer.setProperty(sidebar, 'classList', isOpen ? '-translate-x-full' : '-translate-x-0');
      }
    }
  }

  ngOnInit() {
    this.isMobile = this.checkIsMobile(); // Check for mobile device on initialization

    // Alternatively, use a media query listener for continuous updates
    window.addEventListener('resize', () => {
      this.isMobile = this.checkIsMobile();
    });
  }

  private checkIsMobile(): boolean {
    // Implement your preferred logic for mobile device detection
    // Example using window.matchMedia:
    return window.matchMedia('(max-width: 768px)').matches;

    // You can replace the above with a different detection method that suits your needs
  }
}
