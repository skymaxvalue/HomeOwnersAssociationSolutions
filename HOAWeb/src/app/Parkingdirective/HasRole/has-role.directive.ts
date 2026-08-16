import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { RolePermissionService } from 'src/app/Shared/Services/Permission/role-permission.service';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective {

  constructor( private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef,
    private rolePermissionService: RolePermissionService) 
    { }
    
  @Input() set appHasRole(role: string) {
    if (this.rolePermissionService.hasRole(role)) {
      this.viewContainer.createEmbeddedView(this.templateRef);
    } else {
      this.viewContainer.clear();
    }
  }

}
