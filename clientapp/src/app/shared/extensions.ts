import { Item } from "src/backend/interfaces";

export function sortItemsBySelectedThenTitle(item1: Item, item2: Item) {
   if (item1.selected === item2.selected)
      return item2.title < item1.title ? 1 : -1;
   else if (item1.selected && !item2.selected)
      return 1;
   else
      return -1;
}