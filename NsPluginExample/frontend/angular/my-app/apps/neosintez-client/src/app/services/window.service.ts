import { Injectable } from '@angular/core';


/**Интерфейс для расширения объекта Window */
export interface ICustomWindow extends Window {
  ActiveXObject: Function
  CollectGarbage: () => void;
}

function getWindow(): any {
  return window;
}

/**Сервис для работы с нативным Window */
@Injectable({
  providedIn: 'root'
})
export class WindowService {
  /**Вернет ссылку на windows брузера */
  get nativeWindow(): ICustomWindow {
    return getWindow();
  }
}
