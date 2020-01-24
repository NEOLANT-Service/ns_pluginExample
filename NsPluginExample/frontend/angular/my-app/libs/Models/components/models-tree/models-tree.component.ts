import { map } from 'rxjs/operators';
import { ModelsService, IModel, NodeType } from './../../services/backend/models.service';
import { Component, OnInit, Injectable, Output } from '@angular/core';
import { Subject, BehaviorSubject, Observable, merge } from 'rxjs';
import { FlatTreeControl } from '@angular/cdk/tree';
import { CollectionViewer, SelectionChange } from '@angular/cdk/collections';


/**
 * Database for dynamic data. When expanding a node in the tree, the data source will need to fetch
 * the descendants data from the database.
 */
export class DynamicDatabase {
  dataMap = new Map<string, string[]>([
    ['Fruits', ['Apple', 'Orange', 'Banana']],
    ['Vegetables', ['Tomato', 'Potato', 'Onion']],
    ['Apple', ['Fuji', 'Macintosh']],
    ['Onion', ['Yellow', 'White', 'Purple']]
  ]);

  getChildren(node: string): string[] | undefined {
    return this.dataMap.get(node);
  }

  isExpandable(node: string): boolean {
    return this.dataMap.has(node);
  }
}
/**
 * File database, it can build a tree structured Json object from string.
 * Each node in Json object represents a file or a directory. For a file, it has filename and type.
 * For a directory, it has filename and children (a list of files or directories).
 * The input will be a json object string, and the output is a list of `FileNode` with nested
 * structure.
 */
@Injectable()
export class DynamicDataSource {

  dataChange = new BehaviorSubject<ModelNode[]>([]);

  get data(): ModelNode[] { return this.dataChange.value; }
  set data(value: ModelNode[]) {
    this._treeControl.dataNodes = value;
    this.dataChange.next(value);
  }

  constructor(private _treeControl: FlatTreeControl<ModelNode>,
    private modelService: ModelsService) { }

  connect(collectionViewer: CollectionViewer): Observable<ModelNode[]> {
    this._treeControl.expansionModel.changed.subscribe(change => {
      if ((change as SelectionChange<ModelNode>).added ||
        (change as SelectionChange<ModelNode>).removed) {
        this.handleTreeControl(change as SelectionChange<ModelNode>);
      }
    });

    return merge(collectionViewer.viewChange, this.dataChange).pipe(map(x => this.data));
  }

  /** Handle expand/collapse behaviors */
  handleTreeControl(change: SelectionChange<ModelNode>) {
    if (change.added) {
      change.added.forEach(node => this.toggleNode(node, true));
    }
    if (change.removed) {
      change.removed.slice().reverse().forEach(node => this.toggleNode(node, false));
    }
  }

  /**
   * Toggle the node, remove from display list
   */
  toggleNode(node: ModelNode, expand: boolean) {
    const children = this.modelService.fetchModels(node.item.Id);
    const index = this.data.indexOf(node);
    // if (!children || index < 0) { // If no children, or cannot find the node, no op
    //   return;
    // }

    if (expand) {
      const nodes = children.pipe(map(models =>
        models.map(item => new ModelNode(item, item.Level + 1, item.HasChildren))))
        .subscribe({
          next: x => {
            this.data.splice(index + 1, 0, ...x);
            this.dataChange.next(this.data);
            node.isLoading = false;
          }
        })

    } else {
      let count = 0;
      for (let i = index + 1; i < this.data.length
        && this.data[i].level > node.level; i++ , count++) { }
      this.data.splice(index + 1, count);
      this.dataChange.next(this.data);
      node.isLoading = false;
    }

  }
}


@Component({
  selector: 'app-models-tree',
  templateUrl: './models-tree.component.html',
  styleUrls: ['./models-tree.component.scss']
})
export class ModelsTreeComponent implements OnInit {
  @Output() modelSelectedChange: Subject<IModel> = new Subject();

  treeControl: FlatTreeControl<ModelNode>;
  dataSource: DynamicDataSource;
  nodeTypes = NodeType;

  constructor(modelService: ModelsService) {
    this.treeControl = new FlatTreeControl<ModelNode>(this.getLevel, this.isExpandable);
    this.dataSource = new DynamicDataSource(this.treeControl, modelService);
  }

  ngOnInit() {
    this.fetch();
  }

  hasChild = (_: number, node: ModelNode) => node.item.HasChildren;
  getLevel = (node: ModelNode) => node.level;

  isExpandable = (node: ModelNode) => node.expandable;

  nodeSelectHandler(node: ModelNode) {
    this.modelSelectedChange.next(node.item);
  }

  private fetch() {
    this.dataSource.toggleNode(new ModelNode({ Id: null } as unknown as IModel, 0, true), true);
  }
}

export class ModelNode {
  constructor(public item: IModel, public level: number, public expandable = false, public isLoading = false) {

  }
}
