import java.io.IOException;

public class BOJ_13334{
	
	static int n, d, t[], ans;
	static Heap h1, h2;
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		
		h1 = new Heap(n,0);
		h2 = new Heap(n,1);
		
		while(n-->0)
			h2.put(nex(),nex());
		
		d = nex();
		
		while(h2.size>0) {
			t = h2.remove();
			h1.put(t);
			while(h2.size>0&&h2.heap[1][1]==t[1])
				h1.put(h2.remove());
			while(h1.size>0&&h1.heap[1][0]<t[1]-d)
				h1.remove();
			ans = ans>h1.size?ans:h1.size;
		}
		
		System.out.print(ans);
	}
	
	static int nex() throws IOException{
		int n, c;
		boolean pos = true;
		while((n = System.in.read())<=' ');
		if(n=='-') {
			n = System.in.read();
			pos = false;
		}
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return pos?n:~n+1;
	}
}

class Heap{
	int heap[][], size, comp;
	
	Heap(int n, int c){
		heap = new int[n+1][2];
		size = 0;
		comp = c;
	}
	
	boolean greater(int i, int j) {
		return heap[i][comp]==heap[j][comp]?heap[i][(comp+1)%2]<heap[j][(comp+1)%2]:heap[i][comp]<heap[j][comp];
	}
	
	void swap(int i, int j) {
		heap[0] = heap[i];
		heap[i] = heap[j];
		heap[j] = heap[0];
	}
	
	void up(int i) {
		int t;
		while(i>1&&greater(i,(t=i>>1))) {
			swap(i,t);
			i = t;
		}
	}
	
	void down(int i) {
		int t;
		while((t=i<<1)<=size) {
			if(t<size&&greater(t+1,t)) t++;
			if(greater(i,t)) break;
			swap(i,t);	
			i = t;
		}
	}
	
	void put(int a[]) {
		heap[++size] = a;
		up(size);
	}
	
	void put(int i, int j) {
		heap[++size][0] = i<j?i:j;
		heap[size][1] = i>j?i:j;
		up(size);
	}
	
	int[] remove() {
		int t[] = heap[1];
		heap[1] = heap[size--];
		down(1);
		return t;
	}
}