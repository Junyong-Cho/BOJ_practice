import java.io.IOException;
import java.util.Arrays;

public class BOJ_09576{
	
	static int t, n, m, a[][], count, point;
	static StringBuilder ans = new StringBuilder();
	
	static public void main(String catchsunpie[]) throws IOException{
		
		t = nex();
		
		while(t-->0) {
			n = nex();
			m = nex();
			
			a = new int[m][2];
			heap = new int[m+1];
			size = 
			count = 
			point = 0;

			for(int i = 0; i < m; i++) {
				a[i][0] = nex();
				a[i][1] = nex();
			}
			
			Arrays.sort(a,(i,j)->{
				return i[0]-j[0];
			});
			
			for(int i = a[0][0]; i<=n; i++) {
				while(point<m&&a[point][0]==i)
					add(a[point++][1]);
				while(size>0&&heap[1]<i)
					remove();
				if(size>0) {
					remove();
					count++;
				}
			}
			
			ans.append(count).append("\n");
		}
		
		System.out.print(ans);
	}
	
	static int heap[], size;
	
	static void swap(int i, int j) {
		int t = heap[i];
		heap[i] = heap[j];
		heap[j] = t;
	}
	
	static boolean less(int i, int j) {
		return heap[i]<heap[j];
	}
	
	static void up(int i) {
		int t;
		while(i>1&&less(i,t=i>>1)) {
			swap(i,t);
			i = t;
		}
	}
	
	static void down(int i) {
		int t;
		while((t = i<<1)<=size) {
			if(t<size&&less(t+1,t)) t++;
			if(less(i,t)) break;
			swap(i,t);
			i = t;
		}
	}
	
	static void add(int i) {
		heap[++size] = i;
		up(size);
	}
	
	static int remove() {
		heap[0] = heap[1];
		heap[1] = heap[size--];
		down(1);
		return heap[0];
	}
	
	static int nex() throws IOException{
		int n,c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}
}
