import { Injectable, Optional } from '@angular/core';
import { Router } from '@angular/router';
import { ABP } from '../models';
import { RoutesService } from '../services/routes.service';

@Injectable({
  providedIn: 'root',
})
export class RoutesHandler {
  constructor(private routes: RoutesService, @Optional() private router: Router) {
    this.addRoutes();
  }

  addRoutes() {
    this.router?.config?.forEach(({ path = '', data }) => {
      if (!data?.routes) return;

      if (Array.isArray(data.routes)) {
        this.routes.add(data.routes);
        return;
      }

      const routes = flatRoutes([{ ...data.routes, path }], { path: '' });
      this.routes.add(routes);
    });
  }
}

function flatRoutes(routes: RouteDef[], parent: any) {
  if (!routes) return [];

  return routes.reduce((acc, route) => {
    const current = {
      ...route,
      parentName: parent.name,
      path: parent.path + '/' + route.path,
    };

    acc.push(current, ...flatRoutes(current.children, current));

    return acc;
  }, []);
}

type RouteDef = ABP.Route & { children: RouteDef[] };
