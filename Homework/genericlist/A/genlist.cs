public class genlist<T>{
	public T[] data; // Initialize array to hold data
	public int size {get{return data.Length;}} // Property of the generic list

	public genlist() { // Constructor
		data = new T[0];
	}

	public void push(T elem) { // Push element to list
		T[] newdata = new T[size+1];
		for(int i = 0; i < size; i++) {
			newdata[i] = data[i];
		}
		newdata[size] = elem; // Placing elem at the last place in the array
		data = newdata; // Updating the data array to be the new one, temp is collected by garbage collector
	}
}