public class genlist<T>{
	public T[] data; // Initialize array to hold data
	public int size=0, capacity = 10;

	public genlist() { // Constructor
		data = new T[capacity];
	}

	public void push(T elem) { // Push element to list
		if(size == capacity){
			T[] newdata = new T[capacity*2];
			for(int i = 0; i < size; i++) {
				newdata[i] = data[i];
			}
			data = newdata;
		}
		data[size] = elem;
		size++;
	}

	public void remove(int j) {
		for(int i=j; i<size; i++){
				data[i] = data[i+1];
		}
	}
}