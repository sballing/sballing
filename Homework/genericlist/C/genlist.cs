public class list<T> {
        public node<T> first=null,current=null;
        public void push(T item){
                if(first==null){
                        first=new node<T>(item);
                        current=first;
                }
                else{
                        current.next = new node<T>(item);
                        current=current.next;
                }
        }
        public void start(){ current=first; }
        public void next(){ current=current.next; }
}